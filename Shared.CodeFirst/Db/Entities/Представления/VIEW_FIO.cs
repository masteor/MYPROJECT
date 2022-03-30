using System;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_FIO : Requested
    {
        public int? id_user { get; set;}
        public int? id_new { get; set;}
        public string? fio_full { get; set;}
        public override DateTime? create_date_1 { get; set;}
        public override DateTime? create_date_2 { get; set;}
        public override int? create_request_state { get; set;}
        public override DateTime? end_date_1 { get; set;}
        public override DateTime? end_date_2 { get; set;}
        public override int? end_request_state { get; set;}

        public int id { get; set; }
    }
}
