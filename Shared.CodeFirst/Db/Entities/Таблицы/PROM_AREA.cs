using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Названия территорий, где работают сотрудники
    /// </summary>
    public class PROM_AREA : _EntityBase
    {
        private string _name;

        /*public PROM_AREA()
        {
            BUILDING = new HashSet<BUILDING>();
        }*/

        public int id { get; set; }
        public string name { get; set; }
        
        // public virtual ICollection<BUILDING> BUILDING { get; set; }
    }
}
