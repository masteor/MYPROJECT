namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Фамилии начальников РСО разных подразделений, используются для печатной формы бланка заявки на создание/удаление/изменение ресурса
    /// </summary>
    public class RSO : _EntityBase
    {
        private string _comment;
        
        public int id { get; set; }
        public int id_user { get; set; }
        public string comment { get; set; }

        
        // public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
