using System;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db
{
    public interface IEMPLOYEE_RESPONSIBLE_OWNER
    {
        public int id_user_owner { get; set; }
        public int id_user_responsible { get; set; }
    }
    
    public interface IEMPLOYEE_SENDER_RECIPIENT
    {
        // public int? id_user_sender { get; set; }
        public int? id_user_recipient { get; set; }
    }
    
    /*public interface ILOGIN_RESPONSIBLE_OWNER
    {
        
        public string? login_responsible { get; set; }
        public string? login_owner { get; set; }
    }*/
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class Requested : CreateRequestState 
    {
        // public virtual string? login_responsible { get; set; }
        
        [DataTableColumn("Дата начала заявки на создание")]
        public abstract DateTime? create_date_1 { get; set; }

        [DataTableColumn("Дата завершения заявки на создание")]
        public abstract DateTime? create_date_2 { get; set; }

        [DataTableColumn("Статус заявки на создание")]
        public abstract override int? create_request_state { get; set; }
        
        [DataTableColumn("Дата начала заявки на прекращение")]
        public abstract DateTime? end_date_1 { get; set; }

        [DataTableColumn("Дата завершения заявки на прекращение")]
        public abstract DateTime? end_date_2 { get; set; }

        [DataTableColumn("Статус заявки на прекращение")]
        public abstract int? end_request_state { get; set; }
    }
}