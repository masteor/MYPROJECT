using System;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_RESOURCE_MEMBER_ORG : _EntityBase, IEMPLOYEE_RESPONSIBLE_OWNER // Requested или _EntityBase или другой Entity класс
    {
        public int id_resource_member { get; set; } = 0;
        public int id_resource { get; set; } = 0;
        public int id_object { get; set; } = 0;
        public string fname { get; set; } = "";
        public int id_org { get; set; } = 0;
        public int id_request_1 { get; set; } = 0;
        public int id_request_2 { get; set; } = 0;
        public int id_user_owner { get; set; } = 0;
        public int id_user_responsible { get; set; } = 0;
    }
}
