namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Категория лиц, ответственных за исполнение заявок данного типа
    /// </summary>
    public class REQUEST_TYPE_STAFF : _EntityBase
    {
        public int id { get; set; }
        public int id_request_type { get; set; }
        public int id_staff { get; set; }


        /*public virtual REQUEST_TYPE REQUEST_TYPE { get; set; }
        public virtual STAFF STAFF { get; set; }*/
    }
}
