using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Типы документов: приказ о допуске в сеть, приказ о разрешении, выписка из отдела кадров и т.д.
    /// </summary>
    public class DOC_TYPE : _EntityBase
    {
        private string _name;

        /*public DOC_TYPE()
        {
            DOC = new HashSet<DOC>();
        }*/

        public int id { get; set; }

        public string name { get; set; }

        // public virtual ICollection<DOC> DOC { get; set; }
    }
}
