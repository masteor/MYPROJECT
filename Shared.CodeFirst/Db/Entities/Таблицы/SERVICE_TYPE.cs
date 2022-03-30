using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Тип сервиса
    /// </summary>
    public class SERVICE_TYPE : _EntityBase
    {
        private string _name;
        private string _prefix;
        private string _delimiter;
        private string _wrapper;

        /*public SERVICE_TYPE()
        {
            ТИПЫ_ОБЪЕКТОВ = new HashSet<OBJECT_TYPE>();
            СЕРВИСЫ = new HashSet<SERVICE>();
        }*/

        public int id { get; set; }
        public string название { get; set; }
        public string префикс { get; set; }
        public string разделитель { get; set; }
        public string обёртка { get; set; }
        public int уровень_вложенности { get; set; }


        /*public virtual ICollection<OBJECT_TYPE> ТИПЫ_ОБЪЕКТОВ { get; set; }
        public virtual ICollection<SERVICE> СЕРВИСЫ { get; set; }*/
    }
}
