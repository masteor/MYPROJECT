using System;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        public RESOURCE СоздатьРесурс(RESOURCE resource, RequestParams requestParams, REQUEST? родительскаяЗаявка)
        {
            return СоздатьСущность(БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_RESOURCE,
                resource, requestParams, родительскаяЗаявка); 
            
            var заявка = СоздатьЗаявкуПоИмениТипа
            (БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_RESOURCE, requestParams, родительскаяЗаявка);
            
            resource.id_request_1 = заявка.id;
            var ресурс = CommonService.Создать(resource);
            
            CommonService.Коммитнуть(typeof(RESOURCE));
            
            if (ресурс == null || ресурс.id < 1)
                throw new Exception("Ресурс не создан");

            return ресурс;
        }
    }
}