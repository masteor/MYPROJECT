using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_RESOURCE_USER_RIGHT : _EntityBase
    {
        public int id_object { get; set; }
        public int? id_resource { get; set; }
        public string имя_объекта { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RESOURCE РЕСУРС { get; set; }
    }
}