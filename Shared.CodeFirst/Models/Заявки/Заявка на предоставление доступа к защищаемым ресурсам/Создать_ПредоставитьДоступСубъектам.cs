using System;
using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Helpers;
using QWERTY.Shared.Models._Создатель;
using log4net;

namespace QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам
{
    public class Создать_ПредоставитьДоступСубъектам : Создатель<ДанныеИзФормы>
    {
        private readonly REQUEST request;
        private readonly List<MEMBER>? members = new List<MEMBER>();

        public Создать_ПредоставитьДоступСубъектам
        (
            ICommonService commonService,
            ILog? log,
            string? логинПользователяСервиса,
            ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель? модель,
            REQUEST? родительскаяЗаявка 
        ) 
            : base(
                commonService,
                log,
                логинПользователяСервиса,
                модель,
                родительскаяЗаявка
            )
        {
            
            try
            {
                request = СоздатьЗаявкуПоИмениТипа(
                    БуквенныеКодыТиповЗаявок.ЗаявкаНаПредоставлениеДоступаСубъектам,
                    модель!.request_params!,
                    РодительскаяЗаявка
                );
                
                // проверяем, что профиль существует
                var профиль = commonService.ПолучитьПрофиль(п =>
                    п.id == модель.ProfileId);

                if (профиль == null || профиль.id < 1)
                    throw new ArgumentOutOfRangeException(nameof(профиль));

                // предоставляем доступ сотрудникам
                foreach (var userId in модель.UserIds ?? Array.Empty<int?>())
                {
                    if (userId == null) throw new ArgumentNullException(nameof(userId));

                    // проверяем существует ли пользователь с userId
                    if (commonService.ПолучитьПользователя(l => l.id == userId) == null) 
                        throw new ArgumentOutOfRangeException(nameof(userId));
                    
                    members?.Add(СоздатьПредоставитьДоступ (
                        new MEMBER((int) модель.ProfileId!, userId, null),
                        модель.request_params!,
                        request!
                    ));
                }
                
                // предоставляем доступ структурным единицам
                foreach (var orgId in модель.OrgIds ?? Array.Empty<int?>())
                {
                    if (orgId == null) throw new ArgumentNullException(nameof(orgId));
                    
                    // проверяем существует ли orgId
                    if (commonService.ПолучитьОргСтруктуру(org => org.id == orgId)?.id < 1)
                        throw new ArgumentOutOfRangeException(nameof(orgId));

                    members?.Add(СоздатьПредоставитьДоступ (
                        new MEMBER((int) модель.ProfileId!, null, orgId),
                        модель.request_params!,
                        request!
                    ));
                }
                
                Result = JsonHelper.СоздатьJsonМодель(
                    new
                    {
                        _request = new { request.id },
                        _profileName = профиль!.name,
                        _members = members?.ConvertAll(m 
                            => new
                            {
                                _member = new
                                {
                                    requestId = m.id_request_1,
                                    m.id,
                                    m.id_user,
                                    m.id_org,
                                    m.id_profile
                                }   
                            } 
                        )
                    },
                    Ошибка,
                    $"Заявка на предоставление субъектам доступа к ресурсу для профиля " +
                    $"[{профиль.name}] успешно создана"); 
                
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