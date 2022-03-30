using System;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Helpers;
using QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        public MEMBER СоздатьПредоставитьДоступ(
            MEMBER member,
            RequestParams requestParams,
            REQUEST родительскаяЗаявка
        )
        {
            ЕслиДоступСубъектаДляДанногоПрофиляУжеСуществуетБроситьИсключение(member);

            if (member.id_user == null && member.id_org == null)
                throw new ArgumentOutOfRangeException(nameof(member), 
                    $@"{nameof(member.id_user)}{nameof(member.id_org)}");
            
            if (member.id_user < 1)
                throw new ArgumentOutOfRangeException(nameof(member.id_user));
            
            if (member.id_org < 1)
                throw new ArgumentOutOfRangeException(nameof(member.id_org));
            
            if (member.id_profile < 1)
                throw new ArgumentOutOfRangeException(nameof(member.id_profile));
            
            return СоздатьСущность(
                БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_MEMBER,
                member, requestParams, родительскаяЗаявка);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <exception cref="ArgumentException"></exception>
        private void ЕслиДоступСубъектаДляДанногоПрофиляУжеСуществуетБроситьИсключение(MEMBER member)
        {
            var p = CommonService.ПолучитьДоступСубъекта(m 
                => 
                m.id_user == member.id_user
                && m.id_org == member.id_org
                && m.id_profile == member.id_profile
            );

            if (p == null || p.id < 1) return;
            
            var з = ПолучитьЗаявкуПоИдИлиБроситьИсключение(p.id_request_1); 
            throw new ArgumentException(
                $"У субъекта уже есть доступ, id={p.id}, создан по заявке id={з?.id} дата_создания={з?.date_1} дата_завершения={з?.date_2}");
        }
    }
}