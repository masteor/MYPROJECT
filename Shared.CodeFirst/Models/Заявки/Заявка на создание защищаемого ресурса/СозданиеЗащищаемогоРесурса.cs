using System;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Helpers;
using QWERTY.Shared.Models._Создатель;
using log4net;



namespace QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса
{
    public class СозданиеЗащищаемогоРесурса : Создатель<ДанныеИзФормы>
    {
        public readonly REQUEST? request;
        public readonly OBJECT? объектРесурса;
        public readonly RESOURCE? ресурс;

        public СозданиеЗащищаемогоРесурса
        (
            ICommonService? commonService,
            ILog? log,
            string? логинПользователяСервиса,
            ДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель? модель, 
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
                    БуквенныеКодыТиповЗаявок.ЗаявкаНаСозданиеЗащищаемогоРесурса,
                    модель!.request_params!,
                    РодительскаяЗаявка
                );

                объектРесурса = СоздатьОбъектРесурса(
                    new OBJECT(модель!),
                    модель.request_params!,
                    request!
                );
                
                ресурс = СоздатьСущность (
                    БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_RESOURCE,
                    new RESOURCE(модель!, объектРесурса.id), модель!.request_params!, request!);
                
                // todo: создать документ для созданного ресурса
                
                Result = JsonHelper.СоздатьJsonМодель(
                    new
                    {
                        _request = new {request?.id},
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
                    },
                    Ошибка,
                    $"Заявка на создание защищаемого ресурса [{объектРесурса.name}] успешно создана"
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