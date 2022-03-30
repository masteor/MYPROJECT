using DBPSA.Shared.Db.Entities;

namespace DBPSA.Web.Core.Db
{
    public partial class ОбщиеСервисы
    {
        protected void УдалитьЗаявку(REQUEST заявка) => _RequestService.УдалитьЗаявку(заявка);
        protected REQUEST ПолучитьЗаявкуПоИд(int идЗаявки) => _RequestService.НайтиЗаявкуПоИд(идЗаявки);
    }
}