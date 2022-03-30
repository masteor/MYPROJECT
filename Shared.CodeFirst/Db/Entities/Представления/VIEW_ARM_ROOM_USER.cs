using System;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_ARM_ROOM_USER : Requested
    {
        public int id { get; set; }
        public string? reg_num_arm { get; set; }
        public int arm_id_new { get; set; }
        
        // ид_заявки_постановки_на_учет
        public int arm_id_request_1 { get; set; }
        
        // ид_заявки_снятия_с_учёта
        public int arm_id_request_2 { get; set; }
        public string? reg_num_logbook { get; set; }
        public string? room_num { get; set; }
        public string? building_name { get; set; }
        public string? prom_area_name { get; set; }
        public int arm_user_id_user { get; set; }
        public int user_room_id_user { get; set; }

        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }
    }
}