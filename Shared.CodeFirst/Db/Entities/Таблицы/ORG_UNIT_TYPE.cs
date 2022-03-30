using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Типы структурных единиц организации
    /// </summary>
    public class ORG_UNIT_TYPE : _EntityBase
    {
        private string _name;

        /*public ORG_UNIT_TYPE()
        {
            ORG = new HashSet<ORG>();
        }*/

        public int id { get; set; }
        public string name { get; set; }

        // public virtual ICollection<ORG> ORG { get; set; }
    }
}
