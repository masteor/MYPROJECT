using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class ГруппыПрав
    {
        private readonly object _группыПрав;

        public ГруппыПрав(IEnumerable<RIGHT_DESCR> группыПрав)
        {
                if (группыПрав == null) {
                    return;
                }
                _группыПрав = группыПрав.Select(selector: r => new Тип
                {
                    id = r.id,
                    name = r.description
                });
            }

        public struct Тип
        {
            public int id;
            public string name;
        }
        
        public object Получить() => _группыПрав;
        
    }
}