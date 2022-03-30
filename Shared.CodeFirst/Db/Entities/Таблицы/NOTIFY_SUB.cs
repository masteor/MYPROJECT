namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Подписка обслуживающего персонала на исполнителя заявки
    /// </summary>
    public class NOTIFY_SUB : _EntityBase
    {
        public int id { get; set; }
        public int subscriber { get; set; }
        public int producer { get; set; }
        public int state { get; set; }

        /*public virtual STAFF_UNIT STAFF_UNIT { get; set; }
        public virtual STAFF_UNIT STAFF_UNIT1 { get; set; }*/
    }
}
