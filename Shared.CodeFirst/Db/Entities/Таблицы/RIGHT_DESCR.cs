using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Описание элементарных прав и групп прав
    /// </summary>
    public class RIGHT_DESCR : _EntityBase
    {
        private string _description;

        /*public RIGHT_DESCR()
        {
            ГРУППЫ_ПРАВ = new HashSet<RIGHT_GROUP>();
            ПРАВА = new HashSet<RIGHT_GROUP>();
            ПРАВА_ТИПОВ_ОБЪЕКТОВ = new HashSet<RIGHT_OBJECT_TYPE>();
            RIGHTS = new HashSet<RIGHT>();
        }*/

        public int id { get; set; }
        public string description { get; set; }
        /// <summary>
        /// признак группы
        /// </summary>
        public int? type { get; set; }
        
        public int id_service_type { get; set; }

        
        /*
        public virtual ICollection<RIGHT_GROUP> ГРУППЫ_ПРАВ { get; set; }
        public virtual ICollection<RIGHT_GROUP> ПРАВА { get; set; }
        public virtual ICollection<RIGHT> RIGHTS { get; set; }
        public virtual ICollection<RIGHT_OBJECT_TYPE> ПРАВА_ТИПОВ_ОБЪЕКТОВ { get; set; }
        */

        // private string Тип => type == null ? "Право" : "Группа";
    }
}
