using System;
using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        private protected void ЕслиИмяПрофиляУжеСуществуетБроситьИсключение(PROFILE модель)
        {
            var p = CommonService.ПолучитьПрофиль(profile => profile.name == модель.name);
            
            if (p?.id > 0)
            {
                var з = ПолучитьЗаявкуПоИдИлиБроситьИсключение(p.id_request_1); 
                throw new ArgumentException(
                    $"Профиль с именем={модель.name} уже существует, id={p.id}," +
                    $" создан по заявке id={з?.id} " +
                    $"дата_создания={з?.date_1} " +
                    $"дата_завершения={з?.date_2}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="профиль"></param>
        /// <param name="requestParams"></param>
        /// <param name="родительскаяЗаявка"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public PROFILE СоздатьПрофиль(PROFILE профиль, RequestParams requestParams, REQUEST родительскаяЗаявка)
        {
            ЕслиИмяПрофиляУжеСуществуетБроситьИсключение(профиль);
            
            return СоздатьСущность(БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_PROFILE,
                профиль, requestParams, родительскаяЗаявка);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProfile"></param>
        /// <param name="idObject"></param>
        /// <param name="idRightDescr"></param>
        /// <param name="requestParams"></param>
        /// <param name="родительскаяЗаявка"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        private protected List<RIGHT> СоздатьПраваДляОбъектаПрофиля
        (
            int idProfile,
            int idObject,
            int?[]? idRightDescr,
            RequestParams requestParams,
            REQUEST родительскаяЗаявка
        )
        {
            List<RIGHT> result = new List<RIGHT>();
            
            if (idRightDescr == null || idRightDescr.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(idRightDescr));

            foreach (int? rd in idRightDescr)
            {
                if (rd == null || rd < 1)
                    throw new ArgumentOutOfRangeException(nameof(rd));

                var right = СоздатьПраво(
                    new RIGHT(idObject: idObject, idProfile: idProfile, (int) rd), 
                    requestParams,
                    родительскаяЗаявка);
            
                CommonService.Коммитнуть(typeof(RIGHT));
                
                if (right == null || right.id < 1)
                    throw new Exception(message: "Право для объекта профиля не создано. Обратитесь к администратору сервиса. " +
                                                 $"idProfile={idProfile}, idObject={idObject}, idRightDescr={idRightDescr}");
                
                result.Add(right);
            }

            return result;
        }
    }
}