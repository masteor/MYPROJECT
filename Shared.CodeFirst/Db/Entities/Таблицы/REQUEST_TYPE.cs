using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Тип заявки
    /// </summary>
    public class REQUEST_TYPE : _EntityBase
    {
        private string _name;
        private string _sdescription;

        /*public REQUEST_TYPE()
        {
            REQUEST = new HashSet<REQUEST>();
            // REQUEST_TYPE_1 = new HashSet<REQUEST_TYPE>();
            REQUEST_TYPE_STAFF = new HashSet<REQUEST_TYPE_STAFF>();
        }*/

        public int id { get; set; } = 0;
        public string name { get; set; } = "";
        public string sdescription { get; set; } = "";
        public int? id_parent { get; set; } = 0;
        public int? maintenance { get; set; } = 0;
        public string? code { get; set; } = "";
        public string? templateName { get; set; } = "";



        // public virtual REQUEST_TYPE REQUEST_TYPE_2 { get; set; }
        
        /*public virtual ICollection<REQUEST_TYPE_STAFF> REQUEST_TYPE_STAFF { get; set; }
        public virtual ICollection<REQUEST> REQUEST { get; set; }*/
        // public virtual ICollection<REQUEST_TYPE> REQUEST_TYPE_1 { get; set; }
    }
}
