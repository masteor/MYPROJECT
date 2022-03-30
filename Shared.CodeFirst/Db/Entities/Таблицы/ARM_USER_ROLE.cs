using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Роли пользователей (ответственных?) АРМов
    /// </summary>
    public class ARM_USER_ROLE : _EntityBase
    {
        private string _name;

        /*public ARM_USER_ROLE()
        {
            ARM_USER = new HashSet<ARM_USER>();
        }*/

        public int id { get; set; }
        public string name { get; set; }

        // public virtual ICollection<ARM_USER> ARM_USER { get; set; }
    }
}
