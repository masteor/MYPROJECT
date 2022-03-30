namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_OBJECT_USER_RIGHTS : _EntityBase
    {
        public int id_object { get; set; }
        public string object_name { get; set; }
        public int? id_parent_object { get; set; }
        public int id_object_type { get; set; }
        public int? id_resource { get; set; }
        public int id_profile { get; set; }
        public int id_right_descr { get; set; }
        public string profile_name { get; set; }
        public int? id_login { get; set; }
        public int? id_org { get; set; }
        public int id_member { get; set; }
        public string login_name { get; set; }
        public int id_user { get; set; }
        public int id_domen { get; set; }
        public int id_employee { get; set; }
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
    }
}