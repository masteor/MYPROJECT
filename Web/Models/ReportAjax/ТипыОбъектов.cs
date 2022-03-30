using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class ТипыОбъектов
    {
        private readonly object _типыОбъектов;

        public ТипыОбъектов(IEnumerable<OBJECT_TYPE> типыОбъектов)
        {
            if (типыОбъектов == null) { return; }
            
            _типыОбъектов = типыОбъектов.Select(selector: r => new Тип
            {
                id = r.id,
                name = r.name
            });
        }

        [SuppressMessage(category: "ReSharper", checkId: "InconsistentNaming")]
        public struct Тип
        {
            public int id;
            public string name;
        }

        public object Получить() => _типыОбъектов;
    }
}