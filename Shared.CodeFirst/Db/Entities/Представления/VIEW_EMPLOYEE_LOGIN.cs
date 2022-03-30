namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_EMPLOYEE_LOGIN : _EntityBase // Requested или _EntityBase или другой Entity класс
    {
        public int id_user { get; set;}
        public int tnum { get; set;}
        public string? name_1 { get; set;}
        public string? name_2 { get; set;}
        public string? name_3 { get; set;}
        public string? fio_full { get; set;}
        public string? fio_full_login { get; set;}
        public string? login_name { get; set;}
        public int id_login { get; set;}
        public int id_org { get; set;}
        
        
        public bool? is_active { get; set;}
    }
}
