using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Doc;
using QWERTY.Shared.Enums;
using static QWERTY.Shared.Enums.БуквенныеКодыТиповЗаявок;
using static QWERTY.Shared.Enums.Типы_Документов;
using QWERTY.Shared.Helpers;
using QWERTY.Shared.Models._Создатель;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using QWERTY.Shared.Models.Сущности;
using log4net;

namespace QWERTY.Shared.Models.Заявки
{
    public class СозданиеЗащищаемогоРесурсаЗЛИВС : Создатель<ДанныеИзФормы>
    {
        public readonly REQUEST? request;
        public readonly OBJECT? объектРесурса;
        public readonly RESOURCE? ресурс;
        public readonly List<RESOURCE_MEMBER>? resourceMembers = new List<RESOURCE_MEMBER>();
        public readonly DOC? doc;

        public СозданиеЗащищаемогоРесурсаЗЛИВС
        (
            ICommonService? commonService,
            DocPaths docPaths,
            ILog? log,
            string? логинПользователяСервиса,
            ДанныеИзФормы_СозданиеЗащищаемогоРесурсаЗЛИВС_модель? модель, 
            REQUEST? родительскаяЗаявка
        )
            : base (
                commonService,
                log,
                логинПользователяСервиса,
                модель,
                родительскаяЗаявка
            )
        {
            try
            {
                // создаем главную заявку
                request = СоздатьЗаявкуПоИмениТипа(
                    ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС,
                    модель!.request_params!,
                    РодительскаяЗаявка
                );

                объектРесурса = СоздатьОбъектРесурса(
                    new OBJECT(модель!),
                    модель.request_params!,
                    request!
                );
                
                ресурс = СоздатьСущность (
                    ЗаявкаНаСоздание_RESOURCE,
                    new RESOURCE(модель!, объектРесурса.id),
                    модель!.request_params!,
                    request!
                );
                
                // создание заявки данного типа вынесено из метода создания сущности RESOURCE_MEMBER, 
                // потому что сущностей данного типа создается много и если не вынести создание заявки из сущности
                // тогда у каждой такой сущности будет свой номер заявки, что я считаю избыточным
                var заявкаНаСоздание_RESOURCE_MEMBER = СоздатьЗаявкуПоИмениТипа (
                    ЗаявкаНаСоздание_RESOURCE_MEMBER,
                    модель.request_params!,
                    request
                );
                
                // заполняем таблицу RESOURCE_MEMBER
                // добавляем сотрудников к ресурсу ЗЛИВС
                if (модель?.UserIds != null)
                    foreach (var userId in модель.UserIds)
                    {
                        if (userId == null)
                            throw new ArgumentNullException(nameof(userId));

                        // проверяем существует ли loginId
                        if (commonService?.ПолучитьЛогин(l => l.id == userId)?.id < 1)
                            throw new ArgumentOutOfRangeException(nameof(userId));

                        resourceMembers?.Add(ДобавитьСубъектаКоРесурсуЗЛИВС(
                            new RESOURCE_MEMBER(
                                ресурс!,
                                userId,
                                null
                            ),
                            модель.request_params!,
                            заявкаНаСоздание_RESOURCE_MEMBER
                        ));
                    }

                // добавляем структурные единицы к ресурсу ЗЛИВС
                if (модель?.OrgIds != null)
                    foreach (var orgId in модель.OrgIds)
                    {
                        if (orgId == null)
                            throw new ArgumentNullException(nameof(orgId));

                        // проверяем существует ли orgId
                        if (commonService?.ПолучитьОргСтруктуру(org => org.id == orgId)?.id < 1)
                            throw new ArgumentOutOfRangeException(nameof(orgId));

                        resourceMembers?.Add(ДобавитьСубъектаКоРесурсуЗЛИВС(
                            new RESOURCE_MEMBER(
                                ресурс,
                                null,
                                orgId
                            ),
                            модель.request_params!,
                            заявкаНаСоздание_RESOURCE_MEMBER
                        ));
                    }

                #region Cоздание и сохранение документа
                
                // готовим модель создаваемого документа 
                var модельДокумента = new Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель
                    (commonService, log, ресурс.id);

                // создаем и сохраняем новый документ на диск
                // есть всё хорошо - получаем путь, куда сохранен документ
                IDocument document = new Document(commonService, log, docPaths);
                
                var путьКоСохраненномуДокументу = document
                    .СоздатьИСохранитьВоХранилище(
                        модельДокумента,
                        ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС
                    );

                // создаем документ в бд если документ был создан и сохранен в хранилище приложения
                if (путьКоСохраненномуДокументу != null)
                {
                    doc = СоздатьДокумент(
                        new DOC
                        {
                            id = 0,
                            id_doc_type = (int) заявка,
                            path = путьКоСохраненномуДокументу ??
                                   "", // может так случиться, что документ не будет сохранен на диск, 
                            // исключение выбрасываться не будет, просто в базу запишем пустую строку
                            date_1 = DateTime.Now,
                            state = 1, // пока не используется, значение от балды
                            doc_reg_num = Guid.NewGuid().ToString(), // пока не используется, значение от балды
                            doc_reg_date = DateTime.Today, // пока не используется, значение от балды
                            id_parent = null,
                        },
                        модель?.request_params!,
                        request
                    );
                }

                #endregion

                #region Обновить заявку, добавить ид документа
                
                ДобавитьДокументВоЗаявку(request, doc);
                
                #endregion

                Result = JsonHelper.СоздатьJsonМодель(
                    new
                    {
                        _request = request.id,
                        _resource = new {
                            requestId = ресурс.id_request_1,
                            ресурс.id
                        },
                        _object = new
                        {
                            requestId = объектРесурса.id_request_1,
                            объектРесурса.id,
                            объектРесурса.name,
                        },
                        _members = resourceMembers?.ConvertAll(m 
                            => new
                            {
                                _member = new
                                {
                                    requestId = m.id_request_1,
                                    m.id,
                                    m.id_user,
                                    m.id_org,
                                    m.id_resource
                                }   
                            } 
                        ),
                        _doc = new
                        {
                            id = request?.id_doc,
                            requestId = doc?.id_request_1
                        } 
                    },
                    Ошибка,
                    $"Заявка на создание защищаемого ресурса ЗЛИВС [{объектРесурса.name}] успешно создана"
                );
            }
            catch (Exception e)
            {
                Ошибка = e;
                ОткатитьВсеСозданныеЗаявки(request?.id);
                Result = JsonHelper.СоздатьJsonМодель(Ошибка);
                throw;
            }   
        }

        
    }
}