using System.Collections.Generic;

namespace DBPSA.Web.Core.Db
{
    public partial class ОбщиеСервисы
    {
        protected IEnumerable<string> ПолучитьВсеРусскиеСлова() => _DicService.ПолучитьВсеРусскиеСлова();
    }
}