using System;
using System.Data.Entity.Spatial;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_RIGHT_DESCR : _EntityBase // Requested или _EntityBase или другой Entity класс
    {
        public int id { get; set;}
        public int? id_right_descr { get; set;}
        public int? id_object_type { get; set;}
        public string? description { get; set;}
        public int? type { get; set; }
        public int? id_service_type { get; set;}
        public string? object_type_name { get; set;}
        public int? main_object { get; set;}
    }
}
