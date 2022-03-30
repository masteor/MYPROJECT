using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Формы допуска
    /// </summary>
    public class FORM_PERM : _EntityBase
    {
        /*public FORM_PERM()
        {
            EMPLOYEE = new HashSet<EMPLOYEE>();
            VIEW_OBJECT_USER_RIGHTS_DISTINCTED = new HashSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>();
        }*/

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }


        /*public virtual ICollection<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual ICollection<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> VIEW_OBJECT_USER_RIGHTS_DISTINCTED { get; set; }*/
    }
}
