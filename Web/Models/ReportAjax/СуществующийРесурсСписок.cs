using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Web.Models.ReportAjax
{
    
    public class СуществующийРесурсСписок
    {
        private readonly object _ресурсы = null!;

        public СуществующийРесурсСписок(IEnumerable<VIEW_RESOURCE_EXT>? ресурсы)
        {
            if (ресурсы == null) { return; }
            
            _ресурсы = ресурсы.Select(selector: r => new {
                id = r.id_object,
                name = r.object_name
            });
        }

        public struct Тип
        {
            public int id;
            public string name;
        }

        public object Получить() => _ресурсы;
    }
}