using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class ТипыСервисов
    {
        private readonly object _типыСервисов;

        public ТипыСервисов(List<SERVICE_TYPE> типыСервисов)
        {
            if (типыСервисов == null) { return; }
            _типыСервисов = типыСервисов.Select(selector: r => new Тип
            {
                id = r.id,
                name = r.название
            });
        }

        public struct Тип
        {
            public int id;
            public string name;
        }
        
        public object Получить() => _типыСервисов;
    }
}