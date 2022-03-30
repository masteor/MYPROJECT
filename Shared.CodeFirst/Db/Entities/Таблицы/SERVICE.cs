using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Сервисы, которые используются для размещения ресурсов, в том числе домены с привязкой к фрагменту
    /// </summary>
    public class SERVICE : _EntityBase
    {
        /*public SERVICE()
        {
            SERVICE_1 = new HashSet<SERVICE>();
            
            RESOURCE = new HashSet<RESOURCE>();
        }*/

        public int id { get; set; }
        public string net_name { get; set; }
        public string server_type { get; set; }
        public string description { get; set; }
        public int id_service_type { get; set; }
        public int id_ac_fragment { get; set; }
        public int? id_new { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }

        /*public virtual AC_FRAGMENT AC_FRAGMENT { get; set; }
        public virtual SERVICE_TYPE SERVICE_TYPE { get; set; }
        public virtual SERVICE SERVICE2 { get; set; }
        public virtual REQUEST REQUEST_0 { get; set; }
        public virtual REQUEST REQUEST_1 { get; set; }
        public virtual ICollection<RESOURCE> RESOURCE { get; set; }
        public virtual ICollection<SERVICE> SERVICE_1 { get; set; }*/
        
    }
}
