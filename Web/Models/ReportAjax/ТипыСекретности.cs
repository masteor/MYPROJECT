using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class ТипыСекретности
    {
        private object _типыСекретности;

        public ТипыСекретности(IEnumerable<SECRET_TYPE>? типыСекретности)
        {
            if (типыСекретности == null) { return; }
        
            _типыСекретности = типыСекретности.Select(selector: r => new Тип
            {
                id = r.id,
                name = r.name
            });
        }

        public struct Тип
        {
            public int id;
            public string name;
        }
    
        public object Получить() => _типыСекретности;
    }
}