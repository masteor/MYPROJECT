using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Список сотрудников, обслуживающие данный сервис с привязкой к должностям
    /// </summary>
    public class STAFF_UNIT : _EntityBase
    {
        /*public STAFF_UNIT()
        {
            EXECUTION = new HashSet<EXECUTION>();
            NOTIFY_SUB_0 = new HashSet<NOTIFY_SUB>();
            NOTIFY_SUB_1 = new HashSet<NOTIFY_SUB>();
            STAFF_UNIT_1 = new HashSet<STAFF_UNIT>();
        }*/

        public int id { get; set; }
        public int id_staff { get; set; }
        public int id_user { get; set; }
        public string? login { get; set; }
        public int? id_new { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }

        /*public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual REQUEST REQUEST_0 { get; set; }
        public virtual REQUEST REQUEST_1 { get; set; }
        public virtual STAFF STAFF { get; set; }
        public virtual STAFF_UNIT STAFF_UNIT_2 { get; set; }
        public virtual ICollection<STAFF_UNIT> STAFF_UNIT_1 { get; set; }
        public virtual ICollection<EXECUTION> EXECUTION { get; set; }
        public virtual ICollection<NOTIFY_SUB> NOTIFY_SUB_0 { get; set; }
        public virtual ICollection<NOTIFY_SUB> NOTIFY_SUB_1 { get; set; }*/
        
    }
}
