using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Помещение
    /// </summary>
    public class ROOM : _EntityBase
    {
        /*public ROOM()
        {
            ARM = new HashSet<ARM>();
            USER_ROOM = new HashSet<USER_ROOM>();
        }*/

        public int id { get; set; }
        public string wphone { get; set; }
        public string hphone { get; set; }
        public string num { get; set; }
        public int id_building { get; set; }

        /*public virtual ICollection<ARM> ARM { get; set; }
        public virtual ICollection<USER_ROOM> USER_ROOM { get; set; }
        public virtual BUILDING BUILDING { get; set; }*/
    }
}
