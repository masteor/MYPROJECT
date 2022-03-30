namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_STAFF_UNIT_LOGINS : _EntityBase // Requested или _EntityBase или другой Entity класс
    {
        public int id { get; set;}
        public string name { get; set;}
        public string role { get; set;}
        public string login { get; set;}
        public bool is_active { get; set;}
    }
}
