using System;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Представления
{
    public class VIEW_MEMBER_ORG : _EntityBase // Requested или _EntityBase или другой Entity класс
    {
        public int id { get; set;}
        public int id_member { get; set;}
        public int id_profile { get; set;}
        public int id_user { get; set;}
        public int id_org { get; set;}
        public string org_fname { get; set;}
    }
}
