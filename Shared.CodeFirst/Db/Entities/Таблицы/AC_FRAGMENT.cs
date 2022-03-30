using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Названия различных фрагментов сети ЗЛИВС
    /// </summary>
    public class AC_FRAGMENT : _EntityBase, IId
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string fname { get; set; } = "";
        public string prefix { get; set; } = "";

        public string code { get; set; } = "";


//      public virtual ICollection<SERVICE> ВХОДИТ_В_СЕРВИСЫ { get; set; }

        /*public AC_FRAGMENT()
        {
            ВХОДИТ_В_СЕРВИСЫ = new HashSet<SERVICE>();
        }*/


    }
}
