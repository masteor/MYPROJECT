using System;

namespace DBPSA.Shared.Db.Entities.Представления
{
    public class VIEW_REPORT_RSD_FROM_PRD : Requested, IId // Requested или _EntityBase
    {
        public int id { get; set; }
        public string? resource_name { get; set;}
        public string? profile_name { get; set;}
        public string? login { get; set;}
        public string? org_name { get; set;}
        public string? fio_full { get; set;}
        public int tnum { get; set;}
        public string? job_name { get; set;}
        public string? form_perm { get; set;}
        public override DateTime? create_date_1 { get; set; }
        public override DateTime? create_date_2 { get; set; }
        public override int? create_request_state { get; set; }
        public override DateTime? end_date_1 { get; set; }
        public override DateTime? end_date_2 { get; set; }
        public override int? end_request_state { get; set; }

        
    }
}
