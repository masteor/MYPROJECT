using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class ОргЕдиницы
    {
        private readonly object _orgs = null;
        public ОргЕдиницы(List<ORG> orgStruct)
        {
            _orgs = orgStruct.Select(selector: t => new
            {
                id = t.id,
                name = t.fname
            }).ToList();
        }
        
        public struct Тип
        {
            public int id;
            public string name;
        }
        
        public object Получить() => _orgs;
    }
}