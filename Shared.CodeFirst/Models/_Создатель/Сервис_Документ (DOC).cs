using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;

namespace QWERTY.Shared.Models._Создатель
{
    public partial class Создатель<T> where T : ДанныеИзФормы
    {
        public DOC СоздатьДокумент(DOC doc, RequestParams requestParams, REQUEST? родительскаяЗаявка) 
            =>
            СоздатьСущность(
                БуквенныеКодыТиповЗаявок.ЗаявкаНаСоздание_DOC,
                doc,
                requestParams,
                родительскаяЗаявка
            );
    }
}