using System;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_EMPLOYEE_EXT : _EntityBase
    {
        public int id_user { get; set; }
        public int tnum { get; set; }
        
        // дата_приема_на_работу
        public DateTime date_1 { get; set; }
        
        // дата_увольнения
        public DateTime? date_2 { get; set; }
        public int? id_new { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }
        
        public string job_name { get; set; }
        public string fp_name { get; set; }
        public string fp_description { get; set; }
        public string login_name { get; set; }
        public int id_domen { get; set; }
        public string org_fname { get; set; }
        public string name_1 { get; set; }
        public string name_2 { get; set; }
        public string name_3 { get; set; }
    }
}