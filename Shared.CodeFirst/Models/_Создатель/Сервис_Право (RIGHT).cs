using System;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        private void ЕслиПравоУжеСуществуетБроситьИсключение(RIGHT _)
        {
            var поп = (CommonService.ПолучитьПравоОбъектаПрофиля(r 
                    => 
                    r.id_object == _.id_object
                    && r.id_profile == _.id_profile
                    && r.id_right_descr == _.id_right_descr
                ) ?? throw new InvalidOperationException(
                    nameof(CommonService.ПолучитьПравоОбъектаПрофиля)))
            .FirstOrDefault();

            if (поп?.id > 0)
            {
                var з = CommonService.ПолучитьЗаявкуПоИд(поп.id_request_1);

                throw new ArgumentException(
                    $"ПравоОбъектаПрофиля уже существует, id={поп.id}. ид_объекта={_.id_object}, ид_профиля={_.id_profile}, ид_права={_.id_right_descr}. " +
                    $"создано по заявке id={поп.id_request_1} дата_создания={з.date_1} дата_завершения={з.date_2}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="right"></param>
        /// <param name="requestParams"></param>
        /// <param name="родительскаяЗаявка"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private RIGHT СоздатьПраво(RIGHT right, RequestParams requestParams, REQUEST родительскаяЗаявка)
        {
            ЕслиПравоУжеСуществуетБроситьИсключение(right);
            
            return СоздатьСущность(БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_RIGHT, right, requestParams, родительскаяЗаявка);
            
            /*var заявка = СоздатьЗаявкуПоИмениТипа
                (ТипыЗаявок.ЗаявкаНаСоздание_RIGHT, requestParams, родительскаяЗаявка);

            right.ид_заявки_на_создание = заявка.id;
            var r = CommonService.Создать(right);
            
            CommonService.Коммитнуть(typeof(RIGHT));

            if (r is null || r.id < 1)
                throw new Exception("Право не создано. Обратитесь к администратору сервиса");

            return r;*/
        }
    }
}