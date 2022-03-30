using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// тип секретности ресурса: --/ДСП/КТ
    /// </summary>
    public class SECRET_TYPE : _EntityBase
    {
        /*public SECRET_TYPE()
        {
            RESOURCE = new HashSet<RESOURCE>();
        }*/

        public int id { get; set; }
        public string name { get; set; }

        public string code { get; set; }

        // public virtual ICollection<RESOURCE> RESOURCE { get; set; }
    }
}
