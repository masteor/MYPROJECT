namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Привязка пользователей к комнатам
    /// </summary>
    public class USER_ROOM : _EntityBase
    {
        public int id { get; set; }
        public int id_room { get; set; }
        public int id_user { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }

        
        /*public virtual ROOM? ROOM { get; set; }
        public virtual EMPLOYEE? EMPLOYEE { get; set; }
        public virtual REQUEST? REQUEST_0 { get; set; }
        public virtual REQUEST? REQUEST_1 { get; set; }*/
    }
}
