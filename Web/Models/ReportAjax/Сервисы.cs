using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class Сервисы
    {
        private readonly object _сервисы;

        public Сервисы(IEnumerable<SERVICE> сервисы)
        {
            if (сервисы == null) { return; }
            _сервисы = сервисы.Select(selector: r => new Тип
            {
                id = r.id,
                name = r.net_name
            }).ToList();
        }

        public struct Тип
        {
            public int id;
            public string name;
        }

        public object Получить() => _сервисы;
    }
}