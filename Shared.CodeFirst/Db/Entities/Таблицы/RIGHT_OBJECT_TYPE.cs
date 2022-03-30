namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Связь типов объектов и разрешенных групп прав
    /// </summary>
    public class RIGHT_OBJECT_TYPE : _EntityBase
    {
        public int id { get; set; }
        public int id_right_descr { get; set; }
        public int id_object_type { get; set; }

        /*public virtual RIGHT_DESCR ГРУППА_ПРАВ { get; set; }
        public virtual OBJECT_TYPE ТИП_ОБЪЕКТА { get; set; }

        /// <summary>
        /// Вычисляемые свойства 
        /// </summary>
        public virtual string ИмяГруппыПрав => ГРУППА_ПРАВ == null ? "<имя не известно>" : ГРУППА_ПРАВ.description;
        public virtual string ИмяТипаОбъекта => ТИП_ОБЪЕКТА == null ? "<имя не известно>" : ТИП_ОБЪЕКТА.name;*/
    }
}