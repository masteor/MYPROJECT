namespace QWERTY.Shared.Db.Entities.Таблицы
{
    public class LOGIN : _EntityBase // Requested или _EntityBase или другой Entity класс
    {
        public int id { get; set;}
        public string? name { get; set;}
        public string? email { get; set;}
        public int id_user { get; set;}
        public int id_domen { get; set;}
        public int? id_request_0 { get; set;}
        public int? id_request_1 { get; set;}
        public int? id_request_2 { get; set;}
        public bool is_active { get; set;}
    }
}
