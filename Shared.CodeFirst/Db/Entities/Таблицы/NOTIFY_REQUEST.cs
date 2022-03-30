namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Уведомляемые по заявке пользователи
    /// </summary>
    public class NOTIFY_REQUEST : _EntityBase
    {
        public int id { get; set; }
        public int id_request { get; set; }
        public int id_user { get; set; }

        /*public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual REQUEST REQUEST { get; set; }*/
    }
}
