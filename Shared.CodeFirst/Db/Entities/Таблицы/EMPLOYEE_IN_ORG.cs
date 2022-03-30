namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Принадлежность пользователя определенной структуре
    /// </summary>
    public class EMPLOYEE_IN_ORG : _EntityBase
    /* // warn: в прошлом этот класс называлс¤ EMPLOYEE_ORG и это вызывало ошибку при компил¤ции:
    // типа в коллекции метаданных есть уже с таким названием, проблема возникает потому, что
    // есть еще 2 класса ORG и EMPLOYEE и по-видимому, их имена EF объедин¤ет, поэтому, 
    // класс EMPLOYEE_ORG уже не имеет права на существование, проблема решилась переименованием
    // вышеуказанного класса */
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public int id_org { get; set; }
        public int? id_request_1 { get; set; }
        public int? id_request_2 { get; set; }
        

        /*public virtual EMPLOYEE СОТРУДНИК { get; set; }
        public virtual ORG ORG { get; set; }
        public virtual REQUEST REQUEST { get; set; }
        public virtual REQUEST REQUEST1 { get; set; }*/
    }
}
