using System;
using QWERTY.Shared.Models.Заявки;
using QWERTY.Shared.Атрибуты;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    public class RESOURCE_MEMBER : Id // Requested или _EntityBase или другой Entity класс
    {
        public RESOURCE_MEMBER
        (
            RESOURCE resource,
            // int? loginId,
            int? userId,
            int? orgId
        )
        {
            id_resource = resource.id;
            //id_login = loginId;
            id_user = userId;
            id_org = orgId;
        }

        public RESOURCE_MEMBER()
        {
            
        }

        public override int id { get; set;}
        public int id_resource { get; set;}
        // public int? id_login { get; set;}
        
        public int? id_user { get; set;}
        public int? id_org { get; set;}
        public sealed override int id_request_1 { get; set; } = 0;
        public int? id_request_2 { get; set; } = null;
    }
}
