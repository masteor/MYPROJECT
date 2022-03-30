using System;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_RESOURCES_BY_OT_ST : Requested, IEMPLOYEE_RESPONSIBLE_OWNER
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public int id_object_type { get; set; } = 0;
        public int id_service_type { get; set; } = 0;
        
        public string code { get; set; } = "";
        public string icon { get; set; } = "";

        public int id_ac_fragment { get; set; } = 0;
        
        public string? create_request_state_name { get; set; }
        public string? create_request_state_code { get; set; }
        public string? end_request_state_name { get; set; }
        public string? end_request_state_code { get; set; }

        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        

        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }


        public int id_object { get; set; } = 0;
        public int id_resource { get; set; } = 0;
        public int id_user_responsible { get; set; } = 0;

        public int id_user_owner { get; set; } = 0;
        // public string? login_responsible { get; set; }
        // public string? login_owner { get; set; }
        public int rq1_id { get; set; } = 0;
        public int rq1_parent { get; set; } = 0;
        public int rq2_id { get; set; } = 0;
        public int rq2_parent { get; set; } = 0;
    }
}
