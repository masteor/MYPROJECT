namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Допуск пользователей на АРМ
    /// </summary>
    public class ARM_USER : _EntityBase
    {
        /// <summary>
        /// ARM_USER
        /// </summary>
        public ARM_USER()
        {
            
        }
        
        private int _idUser;
        private int _idArm;
        private int _idRole;
        private int _idRequest1;
        public int id { get; set; }
        public int ид_сотрудника { get; set; }
        public int ид_арма { get; set; }
        public int ид_роли_сотрудника { get; set; }
        public int ид_заявки_разрешения_допуска { get; set; }
        public int? ид_заявки_прекращения_доступа { get; set; }

        /*public virtual ARM ARM { get; set; }
        public virtual ARM_USER_ROLE ARM_USER_ROLE { get; set; }
        public virtual REQUEST ЗАЯВКА_РАЗРЕШЕНИЯ_ДОПУСКА { get; set; }
        public virtual REQUEST ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОПУСКА { get; set; }
        public virtual EMPLOYEE СОТРУДНИК { get; set; }*/

        /*public long ДатаРазрешенияДопускаВТиках {
            get
            {
                // если null - разрешения допуска не было, другими словами дата разрешения допуска не достижима, максимальна
                if (ЗаявкаРазрешенияДопуска?.ДатаЗавершения == null) return DateTime.MaxValue.Ticks;
                    return (long) ЗаявкаРазрешенияДопуска?.ДатаЗавершения?.Ticks;
            }
        }

        public long ДатаПрекращенияДопускаВТиках {
            get {
                // если null - значит допуск не был прекращен, другими словами дата прекращения допуска недостижима, максимальна
                if (ЗаявкаПрекращенияДопуска?.ДатаЗавершения == null) return DateTime.MaxValue.Ticks;
                    return (long) ЗаявкаПрекращенияДопуска?.ДатаЗавершения?.Ticks;
            }
        }*/

        
    }
}
