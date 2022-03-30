using System;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_REPORT_AC_ACCESS : Requested
    {
        [DataTableColumn("№")]
        public int id_ac_access { get; set; }

        [DataTableColumn("Табельный номер")]
        public int tnum { get; set; }

        public string login { get; set; }

        public string fio_full { get; set; }

        [DataTableColumn("Фамилия")]
        public string family { get; set; }

        [DataTableColumn("Имя")]
        public string name { get; set; }

        [DataTableColumn("Отчество")]
        public string patronymic { get; set; }

        [DataTableColumn("Место работы")]
        public string org_fname { get; set; }
        
        public bool is_active { get; set; }
        
        public string is_active_string { get; set; }

        [DataTableColumn("Рег.номер заявки")]
        public string reg_num { get; set; }

        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }
    }
}
