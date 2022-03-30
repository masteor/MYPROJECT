using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Тип разрешений на устройства
    /// </summary>
    public class DEVICE_PERM : _EntityBase
    {
        private string _name;

        /*public DEVICE_PERM()
        {
            ARM_DEVICE = new HashSet<ARM_DEVICE>();
        }*/

        public int id { get; set; }
        public string name { get; set; }

        // public virtual ICollection<ARM_DEVICE> ARM_DEVICE { get; set; }
    }
}
