using QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Субъекты профиля
    /// </summary>
    public class MEMBER : Id
    {
        public MEMBER(int ProfileId, int? userId, int? orgId)
        {
            id_profile = ProfileId;
            id_user = userId;
            id_org = orgId;
            id_request_1 = 0;
            ид_заявки_прекращения_доступа = null;
        }

        public MEMBER()
        {
            
        }

        public override int id { get; set; }
        public int id_profile { get; set; }
        public int? id_user { get; set; }
        public int? id_org { get; set; }
        public sealed override int id_request_1 { get; set; }
        public int? ид_заявки_прекращения_доступа { get; set; }
        
        /*public virtual ORG? ORG { get; set; }
        public virtual PROFILE? PROFILE { get; set; }
        public virtual REQUEST? ЗАЯВКА_ПРЕДОСТАВЛЕНИЯ_ДОСТУПА { get; set; }
        public virtual REQUEST? ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОСТУПА { get; set; }*/
    }
}
