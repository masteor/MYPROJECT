using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class ФормаДопуска
    {
        private object _формыДопуска;

        public ФормаДопуска(IEnumerable<FORM_PERM> формы_допуска)
        {
            if (формы_допуска == null) { return; }
            _формыДопуска = формы_допуска.Select(selector: r => new {
                id = r.id,
                name = r.name + " (" + r.description + ")"
            }).ToList();
        }
        
        public object Получить() => _формыДопуска;
    }
}