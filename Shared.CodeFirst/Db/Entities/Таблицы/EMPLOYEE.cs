using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Extensions.Entity;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Информация о пользователях (сотрудниках, студентах и пр.)
    /// </summary>
    public class EMPLOYEE : _EntityBase
    {
        public  int id { get; set; }
        public int? tnum { get; set; }
        public int? id_job { get; set; }
        public int? id_form_perm { get; set; }
        public int? id_fio { get; set; }
        public DateTime? job_begin_date { get; set; }
        public DateTime? job_end_date { get; set; }
        public int? ид_актуальной_записи { get; set; }
        public int? ид_заявки_создания { get; set; }
        public int? ид_заявки_удаления { get; set; }
        
        /*public EMPLOYEE АКТУАЛЬНАЯ_ЗАПИСЬ { get; set; }
        public FORM_PERM ФОРМА_ДОПУСКА { get; set; }
        public JOB ДОЛЖНОСТЬ { get; set; }
        public FIO ФИО { get; set;}
        public REQUEST ЗАЯВКА_ПРИЁМА_НА_РАБОТУ { get; set; }
        public REQUEST ЗАЯВКА_УВОЛЬНЕНИЯ_СОТРУДНИКА { get; set; }*/

        /*public ICollection<FIO> ИСТОРИЯ_ФИО { get; set; }
        public ICollection<NOTIFY_REQUEST> NOTIFY_REQUEST { get; set; }
        public ICollection<ORG> ORG { get; set; }
        public ICollection<REQUEST> ПОДАННЫЕ_ЗАЯВКИ { get; set; }
        public ICollection<REQUEST> REQUEST3 { get; set; }
        public ICollection<RESOURCE> RESOURCE { get; set; }
        public ICollection<RESOURCE> RESOURCE1 { get; set; }
        public ICollection<STAFF_UNIT> STAFF_UNIT { get; set; }
        public ICollection<USER_ROOM> USER_ROOM { get; set; }
        public ICollection<RSO> RSO { get; set; }
        public ICollection<RESOURCE_RESP> RESOURCE_RESP { get; set; }
        public ICollection<ARM_USER> ARM_USER { get; set; }
        public ICollection<AC_ACCESS> AC_ACCESS { get; set; }
        public ICollection<EMPLOYEE_IN_ORG> ПОЛЬЗОВАТЕЛЬ_В_СТРУКТУРЕ { get; set; }
        public ICollection<EMPLOYEE> EMPLOYEE_OLD { get; set; }*/
        
        /*public EMPLOYEE()
        {
            RESOURCE_RESP = new HashSet<RESOURCE_RESP>();
            AC_ACCESS = new HashSet<AC_ACCESS>();
            ARM_USER = new HashSet<ARM_USER>();
            ПОЛЬЗОВАТЕЛЬ_В_СТРУКТУРЕ = new HashSet<EMPLOYEE_IN_ORG>();
            EMPLOYEE_OLD = new HashSet<EMPLOYEE>();
            ИСТОРИЯ_ФИО = new HashSet<FIO>();
            
            NOTIFY_REQUEST = new HashSet<NOTIFY_REQUEST>();
            ПОДАННЫЕ_ЗАЯВКИ = new HashSet<REQUEST>();
            REQUEST3 = new HashSet<REQUEST>();
            ORG = new HashSet<ORG>(); 
            RESOURCE = new HashSet<RESOURCE>();
            RESOURCE1 = new HashSet<RESOURCE>();
            STAFF_UNIT = new HashSet<STAFF_UNIT>();
            USER_ROOM = new HashSet<USER_ROOM>();
            RSO = new HashSet<RSO>();
        }*/
    }
}
