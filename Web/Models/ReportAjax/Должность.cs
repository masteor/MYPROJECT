using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class Должность
    {
        private object _должности;

        public Должность(IEnumerable<JOB> должности)
        {
            if (должности == null) { return; }
            _должности = должности.Select(selector: r => new {
                id = r.id,
                name = r.name
            }).ToList();
        }

        public object Получить() => _должности;
    }
}