using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class Профиль
    {
        private readonly object _профили;

        public Профиль(IEnumerable<PROFILE> профили)
        {
            if (профили == null) { return; }
            _профили = профили.Select(selector: r => new {
                id = r.id,
                name = r.name
            }).ToList();
        }

        public object Получить() => _профили;
    }
}