using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Зарегистрированные устройства
    /// </summary>
    public class DEVICE : _EntityBase
    {
        private string _regNum;
        private int _idDeviceType;
        private int _idRequest1;

        /*public DEVICE()
        {
            ARM_DEVICE = new HashSet<ARM_DEVICE>();
            DEVICE_OLD = new HashSet<DEVICE>();
        }*/

        public int id { get; set; }
        public string reg_num { get; set; }

        public int id_device_type { get; set; }
        public int? id_new { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }

        /*public virtual DEVICE DEVICE_NEW { get; set; }
        public virtual DEVICE_TYPE DEVICE_TYPE { get; set; }
        public virtual REQUEST REQUEST { get; set; }
        public virtual REQUEST REQUEST1 { get; set; }

        public virtual ICollection<ARM_DEVICE> ARM_DEVICE { get; set; }
        public virtual ICollection<DEVICE> DEVICE_OLD { get; set; }*/
    }
}
