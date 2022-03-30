namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_RESOURCE : _EntityBase // Requested или _EntityBase или другой Entity класс
    {
        public int id_resource { get; set;}
        public string path { get; set;}
        public string description { get; set;}
        
        public string secret_type_name { get; set;}
        public string owner { get; set;}
        public string responsible { get; set;}
        
        public string service_type_name { get; set;}
        public string ac_fragment { get; set;}
        public string object_name { get; set;}
        public string object_type_name { get; set;}
    }
}
