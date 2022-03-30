namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Привязка устройств к АРМам
    /// </summary>
    public class ARM_DEVICE : _EntityBase
    {
        private int _idArm;
        private int _idDevice;
        private int _idDevicePerm;
        private int _idRequest1;
        
        public int id { get; set; }
        public int ид_арма { get; set; }
        public int ид_устройства { get; set; }
        public int ид_типа_разрешения_на_устройство { get; set; }
        public int ид_заявки_начала_разрешения { get; set; }
        public int? ид_заявки_окончания_разрешения { get; set; }

        
        /*public virtual ARM ARM { get; set; }
        public virtual DEVICE DEVICE { get; set; }
        public virtual REQUEST REQUEST { get; set; }
        public virtual REQUEST REQUEST1 { get; set; }
        public virtual DEVICE_PERM DEVICE_PERM { get; set; }*/
    }
}
