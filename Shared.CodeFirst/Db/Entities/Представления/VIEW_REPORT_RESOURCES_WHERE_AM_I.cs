using System;
using System.Data.Entity.Spatial;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_REPORT_RESOURCES_WHERE_AM_I : Requested, IEMPLOYEE_RESPONSIBLE_OWNER // Requested или _EntityBase или другой Entity класс
    {
        
        public int id { get; set;}
        public int id_resource { get; set;}
        public string? resource_name { get; set;}
        public string? object_type_name { get; set;}
        public int? object_type_id { get; set; }
        public string? service_type_name { get; set;}
        public string? service_name { get; set;}
        public int? frag_id { get; set;}
        public string? frag_name { get; set;}
        public string? path { get; set;}
        public string? description { get; set;}
        public string? secret_type_name { get; set;}
        // public string? login_owner { get; set;}
        public string? fio_owner { get; set; }
        // public string? login_responsible { get; set;}
        public string? fio_responsible { get; set; }
        public int id_request_1 { get; set;}
        public int parent_1 { get; set;}
        public string? id_request_type_code_1 { get; set;}
        public override DateTime? create_date_1 { get; set;}
        public override DateTime? create_date_2 { get; set;}
        public string? create_date_2_str { get; set; }
        public override int? create_request_state { get; set;}
        public string? create_request_state_name { get; set;}
        public int id_request_2 { get; set;}
        public int parent_2 { get; set;}
        public string? id_request_type_code_2 { get; set;}
        public override DateTime? end_date_1 { get; set;}
        public override DateTime? end_date_2 { get; set;}
        public override int? end_request_state { get; set;}
        public string? end_request_state_name { get; set;}
        public string? reg_num { get; set;}

        public int id_user_owner { get; set; } = 0;
        public int id_user_responsible { get; set; } = 0;
    }
}
