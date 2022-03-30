using System.Collections.Generic;
using QWERTY.Shared.Db.Validation;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Здания, где работают сотрудники
    /// </summary>
    public sealed class BUILDING : _EntityBase
    {
        private string _name;
        private int _idPromArea;

        /*public BUILDING()
        {
            ROOM = new HashSet<ROOM>();
        }*/
        
        public int id { get; set; }
        public string название_здания { get; set; }
        public int id_prom_area { get; set; }

        /*public PROM_AREA PROM_AREA { get; set; }
        public ICollection<ROOM> ROOM { get; set; }*/
    }
}
