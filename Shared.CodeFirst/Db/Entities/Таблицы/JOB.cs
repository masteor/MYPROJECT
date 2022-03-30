using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Должности
    /// </summary>
    public class JOB : _EntityBase
    {
        private string _name;

        /*public JOB()
        {
            EMPLOYEE = new HashSet<EMPLOYEE>();
            VIEW_OBJECT_USER_RIGHTS = new HashSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>();
        }*/

        public int id { get; set; }
        public string name { get; set; }

        
        /*public virtual ICollection<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual ICollection<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> VIEW_OBJECT_USER_RIGHTS{ get; set; }*/
    }
}
