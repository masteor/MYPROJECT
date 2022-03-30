using System;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Entities.Представления
{
    /// <summary>
    ///
    /// </summary>
    public class VIEW_AC_ACCESS_ORG : _EntityBase
    {
        public int id_ac_access { get; set; }
        
        // ид_заявки_начала_разрешения
        public int id_request_1 { get; set; }
        
        // дата_завершения_заявки_начала_разрешения
        public DateTime? request_1_date_2 { get; set; }
        
        // ид_заявки_окончания_разрешения
        public int? id_request_2 { get; set; }
        
        // дата_завершения_заявки_окончания_разрешения
        public DateTime? request_2_date_2 { get; set; }
        
        // таб_номер
        public int tnum { get; set; }
        public int id_org { get; set; }
        public string org_fname { get; set; }
        public int id_org_parent { get; set; }
        public int id_org_unit_type { get; set; }
        public string org_unit_type_name { get; set; }
        
        // фамилия
        public string name_1 { get; set; }
        
        // имя
        public string name_2 { get; set; }
        
        // отчество
        public string name_3 { get; set; }

        /*public virtual REQUEST ЗАЯВКА_РАЗРЕШЕНИЯ_ДОПУСКА { get; set; }
        public virtual REQUEST ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОПУСКА { get; set; }*/
    }
}
