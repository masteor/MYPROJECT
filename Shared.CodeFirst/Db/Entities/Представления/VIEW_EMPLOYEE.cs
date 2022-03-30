namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_EMPLOYEE : _EntityBase // Requested или _EntityBase или другой Entity класс
    {
        public int id_employee { get; set;}
        public int tnum { get; set;}
        public string employee_fio_full { get; set;}
        public string login { get; set;}
        public bool is_active { get; set;}
        public string is_active_descr { get; set;}
        public string job_name { get; set;}
        public string form_perm { get; set;}
        public string wphone { get; set;}
        public string hphone { get; set;}
        public string build { get; set;}
        public string prom_area { get; set;}
        public string room { get; set;}
        
        public string dep_descr { get; set;}
        public string dep_utype_name { get; set;}
        public string dep_utype_code { get; set;}
        
        public string div_descr { get; set;}
        public string div_utype_name { get; set;}
        public string div_utype_code { get; set;}
    }
}
