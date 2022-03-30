using DBPSA.Shared.Db.Entities;

namespace DBPSA.Web.Core.Db
{
    public partial class ОбщиеСервисы
    {
        protected DOC ПолучитьДокументПоИд(int идДокумента) => _DocService.ПолучитьДокументПоИд(идДокумента);
        
    }
}