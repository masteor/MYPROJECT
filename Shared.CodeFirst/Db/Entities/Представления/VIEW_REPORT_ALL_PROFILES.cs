using System;
using System.Data.Entity.Spatial;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_REPORT_ALL_PROFILES : _EntityBase, IEMPLOYEE_SENDER_RECIPIENT // Requested или _EntityBase или другой Entity класс
    {
        public int id { get; set;}
        public int? id_right_descr { get; set; }
        public string description { get; set; } = "";
        public int? id_profile { get; set; }
        public int? id_request { get; set; }
        public int? id_request_parent { get; set; }
        public string? frag_name { get; set;}
        public string? object_type_name { get; set;}
        public string? profile_name { get; set;}
        public string? resource_name { get; set;}
        public string? secret_type_name { get; set;}
        public string? service_type_name { get; set;}
        public int? id_user_sender { get; set; }
        public int? id_user_recipient { get; set; }
        
        /*public string? org_fname { get; set;}
        public string? recipient { get; set;}
        public string? reg_num { get; set;}
        public string? sender { get; set;}
        public string? service_name { get; set;}
        public string? id_request_type_code_1 { get; set;}
        public string? id_request_type_code_2 { get; set;}
        public int id_request_1 { get; set;}
        public int id_request_2 { get; set;}
        public int parent_1 { get; set;}
        public int parent_2 { get; set;}*/
        
        /*public override DateTime? create_date_1 { get; set;}
        public override DateTime? create_date_2 { get; set;}
        public override DateTime? end_date_1 { get; set;}
        public override DateTime? end_date_2 { get; set;}
        public override int? create_request_state { get; set;}
        public override int? end_request_state { get; set;}*/
    }
}
