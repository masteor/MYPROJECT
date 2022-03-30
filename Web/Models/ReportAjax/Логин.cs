using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class Логин
    {
        private object _логины;

        public Логин(IEnumerable<LOGIN> логины)
        {
            if (логины == null) { return; }
            _логины = логины.Select(selector: r => new {
                id = r.id,
                name = r.name
            }).ToList();
        }
        
        public object Получить() => _логины;
    }
}