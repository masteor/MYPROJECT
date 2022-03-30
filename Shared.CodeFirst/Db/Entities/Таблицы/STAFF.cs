using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Должности сотрудников обслуживающих сервис с привязкой к ролям
    /// </summary>
    public class STAFF : _EntityBase
    {
        /*public STAFF()
        {
            REQUEST_TYPE_STAFF = new HashSet<REQUEST_TYPE_STAFF>();
            STAFF_1 = new HashSet<STAFF>();
            STAFF_UNIT = new HashSet<STAFF_UNIT>();
        }*/

        public int id { get; set; }
        public string name { get; set; }

        public string role { get; set; }

        public int? id_new { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }

        /*public virtual STAFF STAFF2 { get; set; }
        public virtual REQUEST REQUEST_0 { get; set; }
        public virtual REQUEST REQUEST_1 { get; set; }
        public virtual ICollection<STAFF> STAFF_1 { get; set; }
        public virtual ICollection<STAFF_UNIT> STAFF_UNIT { get; set; }
        public virtual ICollection<REQUEST_TYPE_STAFF> REQUEST_TYPE_STAFF { get; set; }*/
    }
}
