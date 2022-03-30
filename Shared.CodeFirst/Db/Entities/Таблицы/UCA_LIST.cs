using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Пункты перечней для ресурсов, на которых хранятся секретные документы
    /// </summary>
    public class UCA_LIST : _EntityBase
    {
        private string _name;

        /*public UCA_LIST()
        {
            RESOURCE_UCA = new HashSet<RESOURCE_UCA>();
        }*/

        public int id { get; set; }
        public string name { get; set; }

        // public virtual ICollection<RESOURCE_UCA> RESOURCE_UCA { get; set; }
    }
}
