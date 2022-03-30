using System;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        private protected void ЕслиОбъектРесурсаУжеСуществуетБроситьИсключение(OBJECT модель)
        {
            var o = CommonService.ПолучитьОбъектРесурса(e=> 
                e.name == модель?.name
                && e.id_object_type == модель.id_object_type
                && e.id_parent_object == модель.id_parent_object
            );
            
            if (o != null && o.id > 0)
                throw new ArgumentException($"Объект ресурса с именем={модель?.name} уже существует, id={o.id}, id_object_type={o.id_object_type}, id_parent_object={o.id_parent_object}");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="объект"></param>
        /// <param name="requestParams"></param>
        /// <param name="родительскаяЗаявка"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public OBJECT СоздатьОбъектРесурса(OBJECT объект, RequestParams requestParams, REQUEST родительскаяЗаявка)
        {
                // проверяем уникальность имени создаваемого объекта
                ЕслиОбъектРесурсаУжеСуществуетБроситьИсключение(объект);

                return СоздатьСущность(
                    БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_OBJECT,
                    объект,
                    requestParams,
                    родительскаяЗаявка
                );
                
                /*var заявка = СоздатьЗаявкуПоИмениТипа
                    (ТипыЗаявок.ЗаявкаНаСоздание_OBJECT, requestParams, родительскаяЗаявка);

                объект.ид_заявки_на_создание = заявка.id;
                var o = CommonService?.Создать(объект);
                
                CommonService!.Коммитнуть(typeof(OBJECT));

                if (o == null || o.id < 1)
                    throw new Exception($"Объект не создан. Обратитесь к администратору сервиса. идЗаявка={заявка.id}");*/

                /*return o;*/
        }
    }
}