using System.Collections.Generic;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// ФИО пользователей
    /// </summary>
    public class FIO : _EntityBase
    {
        /*public FIO()
        {
            EMPLOYEES = new HashSet<EMPLOYEE>();    
        }*/
        
        public int? id_user { get; set; }
        public string family { get; set; }
        public string patronymic { get; set; }
        public string name { get; set; }


        public int? id_new { get; set; }
        public int ид_заявки_на_создание { get; set; }
        public int? ид_заявки_на_удаление { get; set; }

        
        /*public virtual FIO FioNew { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual REQUEST REQUEST_0 { get; set; }
        public virtual REQUEST REQUEST_1 { get; set; }
        
        public virtual ICollection<EMPLOYEE> EMPLOYEES { get; set; }
        public virtual ICollection<FIO> FIOs_OLD { get; set; }*/

        /// <summary>
        /// Вычисляемые свойства
        /// </summary>
        public string ПолучитьПолноеФИО
        {
            get
            {
                var r = string.Empty;
                if (!(string.IsNullOrWhiteSpace(family) || family.Length < 1)) {r += family;}

                if (!(string.IsNullOrWhiteSpace(name) || name.Length < 1))
                {
                    if (!string.IsNullOrEmpty(r)) r += " ";
                    r += name;
                }

                if (!(string.IsNullOrWhiteSpace(patronymic) || patronymic.Length < 1))
                {
                    if (!string.IsNullOrEmpty(r)) r += " ";
                    r += patronymic;
                }
                
                return r;
            }
        }

        public string ПолучитьКороткоеФИО
        {
            get
            {
                var r = string.Empty;
                if (!(string.IsNullOrWhiteSpace(family) || family.Length < 1)) r += family;
                if (!(string.IsNullOrWhiteSpace(name) || name.Length < 1)) r += name[0];
                if (!(string.IsNullOrWhiteSpace(patronymic) || patronymic.Length < 1)) r += patronymic[0];
                return r;
            }
        }

        public int id { get; set; }
    }
}
