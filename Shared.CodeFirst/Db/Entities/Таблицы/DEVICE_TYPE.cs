using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Типы устройств
    /// </summary>
    public class DEVICE_TYPE : _EntityBase
    {
        private string _name;

        /*public DEVICE_TYPE()
        {
            DEVICE = new HashSet<DEVICE>();
        }*/

        public int id { get; set; }
        public string name{ get; set; }

//        public virtual ICollection<DEVICE> DEVICE { get; set; }
    }
}
