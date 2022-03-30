using System;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_ARM_USER : Requested
    {
        public int id { get; set; }
        
        public string sfio { get; set; }
        public int tnum { get; set; }
        public string? arm_reg_num { get; set; }
        public string? arm_user_role_name { get; set; }
        
        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }

        
    }
}
