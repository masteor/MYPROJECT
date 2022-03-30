using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Models.ReportAjax
{
    public class ФИО
    {
        private object _фио;

        public ФИО(IEnumerable<FIO> фио)
        {
            if (фио == null) { return; }
            _фио = фио.Select(selector: r => new {
                id = r.id,
                name = r.ПолучитьПолноеФИО
            }).ToList();
        }
        
        public ФИО(FIO фио)
        {
            if (фио == null) { return; }

            _фио = new
            {
                фио.id,
                idEmployee = фио.id_user,
                family = фио.family,
                name = фио.name,
                patronymic = фио.patronymic,
                idRequestCreate = фио.ид_заявки_на_создание,
                idRequestBanned = фио.ид_заявки_на_удаление
            };
        }
        
        public object Получить() => _фио;
    }
}