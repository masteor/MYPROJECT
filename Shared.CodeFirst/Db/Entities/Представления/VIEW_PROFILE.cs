using System;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_PROFILE : Requested, IEMPLOYEE_SENDER_RECIPIENT
    {
        public int id { get; set;}
        public string? profile_name { get; set;}
        public int id_ac_fragment { get; set; }
        public int? id_user_recipient { get; set; }
        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }
    }
}
