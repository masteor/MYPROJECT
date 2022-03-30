namespace QWERTY.Shared.Db.Entities.Системные_таблицы
{
    public class ATTRI : _EntityBase
    {
        /// <summary>
        /// ид таблицы
        /// </summary>
        public int S21 { get; set;}
        /// <summary>
        /// ид поля в таблице
        /// </summary>
        public short  S22 { get; set; }
        /// <summary>
        /// имя поля в таблице
        /// </summary>
        public string S23 { get; set; }

    }
}
