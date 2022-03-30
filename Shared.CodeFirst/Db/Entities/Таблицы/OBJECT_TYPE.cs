using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Типы объектов сервиса
    /// </summary>
    public class OBJECT_TYPE : _EntityBase
    {
        /*public OBJECT_TYPE()
        {
            VIEW_OBJECT_USER_RIGHTS_DISTINCTED = new HashSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>();
            OBJECT = new HashSet<OBJECT>();
            ПРАВА_ТИПОВ_ОБЪЕКТОВ = new HashSet<RIGHT_OBJECT_TYPE>();
        }*/

        public int id { get; set; }
        public string name { get; set; }
        public int id_service_type { get; set; }
        public int? main_object { get; set; }
        
        public string? code { get; set; }
        
        public string? icon { get; set; }

        /*public virtual SERVICE_TYPE SERVICE_TYPE { get; set; }
        public virtual ICollection<OBJECT> OBJECT { get; set; }
        public virtual ICollection<RIGHT_OBJECT_TYPE> ПРАВА_ТИПОВ_ОБЪЕКТОВ { get; set; }
        public virtual ICollection<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> VIEW_OBJECT_USER_RIGHTS_DISTINCTED { get; set; }*/
        
        // public virtual string НазваниеТипаСервиса => SERVICE_TYPE == null ? "<имя не известно>" : SERVICE_TYPE.название;
    }
}
