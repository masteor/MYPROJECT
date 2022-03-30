using System;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_REPORT_ALL_REQUESTS : CreateRequestState // Requested или _EntityBase или другой Entity класс
    {
        public int id { get; set; }
        public int id_request { get; set;}
        public int? parent { get; set; }
        
        public string? datestr_1 { get; set; }
        public DateTime? date_1 { get; set;}
        public string? sender { get; set;}
        
        public int id_user_sender { get; set; }
        public string? recipient { get; set;}
        
        public int id_user_recipient { get; set; }
        public string? request_type_name { get; set;}
        public string? request_type_code { get; set; }
        public string? request_state_name { get; set;}
        public override int? create_request_state { get; set; }
        public int? id_doc { get; set;}
    }
}
