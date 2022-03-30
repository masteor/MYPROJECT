namespace DBPSA.Shared.Db.Entities.Представления
{
    public class VIEW_EMPLOYEE_LOGIN_PRD : _EntityBase // Requested или _EntityBase или другой Entity класс
    {
        public int id { get; set;}
        public string name1 { get; set; } = "";
        public string name2 { get; set; } = "";
        public string name3 { get; set; } = "";
        public string login { get; set; } = "";
        public bool is_active { get; set;}
        
        public string ПолучитьПолноеФио => $"{ЧекнутьФИО(name1)} {ЧекнутьФИО(name2)} {ЧекнутьФИО(name3)}";
        public string ПолучитьКороткоеФИО => $"{ЧекнутьФИО(name1)} {Инициал(name2)}.{Инициал(name3)}.";
        public string ЧекнутьФИО(string s) => string.IsNullOrWhiteSpace(s) ? string.Empty : s;
        public string Инициал(string s) => string.IsNullOrEmpty(s) ? string.Empty : s[0].ToString();
    }
}
