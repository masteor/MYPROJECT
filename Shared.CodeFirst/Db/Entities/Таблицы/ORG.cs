using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Структурная схема организации, органограмма
    /// </summary>
    public class ORG : _EntityBase
    {
        private string _kod;
        private string _fname;

        /*public ORG()
        {
            СОТРУДНИКИ_В_СТРУКТУРЕ_1 = new HashSet<EMPLOYEE_IN_ORG>();
            СОТРУДНИКИ_В_СТРУКТУРЕ_2 = new HashSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>();
            СОТРУДНИКИ_В_СТРУКТУРЕ_3 = new HashSet<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>();
            MEMBER = new HashSet<MEMBER>();
            ДОЧЕРНИЕ_СТРУКТУРЫ = new HashSet<ORG>();
            ORG_OLD = new HashSet<ORG>();
        }*/

        public int id { get; set; }
        public int kod { get; set; } 
        public string fname { get; set; }
        public int id_user_boss { get; set; }
        public int? id_parent { get; set; }
        public int id_unit_type { get; set; }
        public int? id_new { get; set; }
        public bool is_active { get; set; }
        public int id_request_1 { get; set; }
        public int? id_request_2 { get; set; }

        /*public virtual EMPLOYEE БОСС { get; set; }
        public virtual ORG_UNIT_TYPE ORG_UNIT_TYPE { get; set; }
        public virtual ORG ORG_PARENT { get; set; }
        public virtual ORG ORG_NEW { get; set; }
        public virtual REQUEST REQUEST { get; set; }
        public virtual REQUEST REQUEST1 { get; set; }
        public virtual ICollection<EMPLOYEE_IN_ORG> СОТРУДНИКИ_В_СТРУКТУРЕ_1 { get; set; }
        public virtual ICollection<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> СОТРУДНИКИ_В_СТРУКТУРЕ_2 { get; set; }
        public virtual ICollection<VIEW_OBJECT_USER_RIGHTS_DISTINCTED> СОТРУДНИКИ_В_СТРУКТУРЕ_3 { get; set; }
        public virtual ICollection<MEMBER> MEMBER { get; set; }
        public virtual ICollection<ORG> ДОЧЕРНИЕ_СТРУКТУРЫ { get; set; }
        public virtual ICollection<ORG> ORG_OLD { get; set; }*/
    }
}
