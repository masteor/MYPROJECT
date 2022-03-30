namespace QWERTY.Shared.Db.Entities.Таблицы
{
    public class RESOURCE_RESP : _EntityBase
    {
        /// <summary>
        /// Ответственные за ресурс
        /// </summary>
        public int id { get; set; }
        public int id_resource { get; set; }
        public int id_user { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }


        /*public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual REQUEST REQUEST_0 { get; set; }
        public virtual REQUEST REQUEST_1 { get; set; }*/
    }
}
