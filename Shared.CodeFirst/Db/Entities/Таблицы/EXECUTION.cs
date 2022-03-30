using System;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Процесс исполнения заявки
    /// </summary>
    public class EXECUTION : _EntityBase
    {
        private DateTime _date1;
        
        public int id { get; set; }
        public int id_request { get; set; }
        public int id_executor { get; set; }
        public DateTime date_1 { get; set; }
        public DateTime? date_2 { get; set; }
        public int id_request_state_1 { get; set; }
        public int? id_request_state_2 { get; set; }

        /*public virtual REQUEST_STATE REQUEST_STATE { get; set; }
        public virtual REQUEST_STATE REQUEST_STATE1 { get; set; }*/
        /*public virtual REQUEST REQUEST { get; set; }
        public virtual STAFF_UNIT STAFF_UNIT { get; set; }*/
    }
}
