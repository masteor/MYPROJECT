using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_OBJECT_USER_RIGHTS_DISTINCTED : _EntityBase
    {
        public int id_object { get; set; }
        public string object_name { get; set; }
        public int id_parent_object { get; set; }
        public int id_object_type { get; set; }
        public int id_resource { get; set; }
        public int id_profile { get; set; }
        public string profile_name { get; set; }
        public int id_login { get; set; }
        public int id_org { get; set; }
        public int id_member { get; set; }
        public int id_member_request_1 { get; set; }
        public int id_member_request_2 { get; set; }
        public string login_name { get; set; }
        public int id_user { get; set; }
        public int id_domen { get; set; }
        public int id_employee { get; set; }
        public int id_org_employee_in_org { get; set; }
        public int tnum { get; set; }
        public int id_job { get; set; }
        public int id_form_perm { get; set; }
        public int id_fio { get; set; }
        
        // фамилия
        public string name_1 { get; set; }
        
        // имя
        public string name_2 { get; set; }
        
        // отчество
        public string name_3 { get; set; }

        /*public virtual RESOURCE РЕСУРС { get; set; }
        public virtual REQUEST ЗАЯВКА_ПРЕДОСТАВЛЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ { get; set; }
        public virtual REQUEST ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ { get; set; }

        public virtual ORG СТРУКТУРНАЯ_ЕДИНИЦА_ПОЛЬЗОВАТЕЛЯ { get; set; }
        public virtual ORG СТРУКТУРНАЯ_ЕДИНИЦА_С_ДОСТУПОМ { get; set; }
        public virtual JOB ДОЛЖНОСТЬ { get; set; }
        public virtual FORM_PERM ФОРМА_ДОПУСКА { get; set; }
        public virtual OBJECT_TYPE ТИП_ОБЪЕКТА { get; set; }*/
    }
}
