using System;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_PROFILE_OBJECT_RIGHT : _EntityBase, IEMPLOYEE_RESPONSIBLE_OWNER, IEMPLOYEE_SENDER_RECIPIENT
        // Requested или _EntityBase или другой Entity класс
    {
        public int id_right { get; set; } = 0;
        public int id_profile { get; set; } = 0;
        public string profile_name { get; set; } = "";
        public int id_object { get; set; } = 0;
        public int id_parent_object { get; set; } = 0;
        public string object_name { get; set; } = "";
        public string object_type_name { get; set; } = "";
        public int id_right_descr { get; set; } = 0;
        public string description { get; set; } = "";
        public int id_user_owner { get; set; } = 0;
        public int id_user_responsible { get; set; } = 0;
        public int? id_user_recipient { get; set; } = 0;
    }
}
