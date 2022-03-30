using System;
using DBPSA.Shared.Атрибуты;

namespace DBPSA.Shared.Db.Entities.Представления
{
    public class VIEW_REPORT_AC_ACCESS_PRD : Requested
    {
        public int id { get; set; }
        public int tnum { get; set; }
        public string family { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string org_fname { get; set; }
        public bool is_active { get; set; }
        public string reg_num { get; set; }

        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }
    }
}