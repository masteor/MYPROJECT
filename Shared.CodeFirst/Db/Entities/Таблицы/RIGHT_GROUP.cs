namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Права, группы прав и их связи
    /// </summary>
    public class RIGHT_GROUP : _EntityBase
    {
        public RIGHT_GROUP()
        {
            /*RIGHT_DESCR = new HashSet<RIGHT_DESCR>();*/
        }

        public int id { get; set; }
        public int? id_group { get; set; }
        public int? id_right { get; set; }

        public string description { get; set; }
        
        
        /*public virtual RIGHT_DESCR ГРУППА { get; set; }
        public virtual RIGHT_DESCR ЭЛЕМ_ПРАВО { get; set; }*/
    }
}
