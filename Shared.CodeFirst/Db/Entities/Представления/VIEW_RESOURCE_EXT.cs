using System;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_RESOURCE_EXT : Requested
    {
        public int id_resource { get; set; }
        public int? resource_id_object { get; set; }
        public int? id_object { get; set; }
        public string? object_name { get; set; }
        public int? id_object_type { get; set; }
        public string? object_type_name { get; set; }
        public int? id_service_type { get; set; }
        
        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }
    }
}