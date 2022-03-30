using System;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Extensions;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы 
    {
        public RESOURCE_MEMBER ДобавитьСубъектаКоРесурсуЗЛИВС(
            RESOURCE_MEMBER resourceMember,
            RequestParams requestParams,
            REQUEST родительскаяЗаявка
        )
        {
            ЕслиСубъектУжеДобавленКоРесурсуБроситьИсключение(resourceMember);

            if (resourceMember.id_user == null && resourceMember.id_org == null)
                throw new ArgumentOutOfRangeException(nameof(resourceMember), 
                    $@"{nameof(resourceMember.id_user)}{nameof(resourceMember.id_org)}");
            
            if (resourceMember.id_user < 1)
                throw new ArgumentOutOfRangeException(nameof(resourceMember.id_user));
            
            if (resourceMember.id_org < 1)
                throw new ArgumentOutOfRangeException(nameof(resourceMember.id_org));
            
            if (resourceMember.id_resource < 1)
                throw new ArgumentOutOfRangeException(nameof(resourceMember.id_resource));
            
            return СоздатьСущностьПоРодительскойЗаявке(
                БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_RESOURCE_MEMBER,
                entity: resourceMember,
                requestParams: requestParams,
                заявка: родительскаяЗаявка
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceMember"></param>
        /// <exception cref="ArgumentException"></exception>
        private void ЕслиСубъектУжеДобавленКоРесурсуБроситьИсключение(RESOURCE_MEMBER resourceMember)
        {
            var p = CommonService.ПолучитьСубъектаРесурсаЗЛИВС(m 
                => 
                m.id_user == resourceMember.id_user
                && m.id_org == resourceMember.id_org
                && m.id_resource == resourceMember.id_resource
            );

            if (p == null || p.id < 1) return;
            
            var з = ПолучитьЗаявкуПоИдИлиБроситьИсключение(p.id_request_1);
            
            throw new ArgumentException(
                $"У субъекта уже есть допуск (не доступ!) к ресурсу ЗЛИВС, id={p.id}, создан по заявке id={з?.id} дата_создания={з?.date_1} дата_завершения={з?.date_2}");
        }
    }
}