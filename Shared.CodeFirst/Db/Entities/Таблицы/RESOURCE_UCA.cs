namespace QWERTY.Shared.Db.Entities.Таблицы
{
    public class RESOURCE_UCA : _EntityBase
    {
        /// <summary>
        /// Пункты перечней ресурса
        /// </summary>
        public int id { get; set; }
        public int id_uca_list { get; set; }
        public int id_resource { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }

        /*public virtual UCA_LIST UCA_LIST { get; set; }
        public virtual REQUEST REQUEST_0 { get; set; }
        public virtual REQUEST REQUEST_1 { get; set; }
        public virtual RESOURCE RESOURCE { get; set; }*/
    }
}
