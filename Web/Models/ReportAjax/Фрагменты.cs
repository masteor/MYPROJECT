using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class Фрагменты
    {
        private readonly object _типыФрагментов;

        public Фрагменты(List<AC_FRAGMENT> типыФрагментов)
        {
            if (типыФрагментов == null) { return; }
            _типыФрагментов = типыФрагментов.Select(selector: r => new Тип
            {
                id = r.id,
                name = r.fname
            });
        }

        public struct Тип
        {
            public int id;
            public string name;
        }
        
        public object Получить() => _типыФрагментов;
    }
}