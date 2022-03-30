using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Состояние заявки
    /// </summary>
    public class REQUEST_STATE : _EntityBase
    {
        /*public REQUEST_STATE()
        {
            EXECUTION_0 = new HashSet<EXECUTION>();
            EXECUTION_1 = new HashSet<EXECUTION>();
            REQUEST = new HashSet<REQUEST>();
        }*/

        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }

        /*public virtual ICollection<EXECUTION> EXECUTION_0 { get; set; }
        public virtual ICollection<EXECUTION> EXECUTION_1 { get; set; }
        public virtual ICollection<REQUEST> REQUEST { get; set; }*/
    }
}
