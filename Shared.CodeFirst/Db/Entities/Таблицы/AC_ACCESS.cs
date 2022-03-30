namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Таблица разрешения/запрещения допуска сотрудников к работе в АС
    /// </summary>
    public class AC_ACCESS : _EntityBase // AC_ACCESS
    {
        public int id { get; set; }
        public int ид_пользователя { get; set; }
        public string номер_приказа_о_допуске { get; set; }
        public int? ид_заявки_разрешения_допуска { get; set; }
        public int? ид_заявки_прекращения_допуска { get; set; }
        
        // public EMPLOYEE СОТРУДНИК { get; set; }
        // public REQUEST ЗАЯВКА_РАЗРЕШЕНИЯ_ДОПУСКА { get; set; }
        // public REQUEST ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОПУСКА { get; set; }
    }
}