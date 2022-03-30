using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_MEMBER_ORG_Repository : IRepository<VIEW_MEMBER_ORG>
    {

    }

    public class VIEW_MEMBER_ORG_Repository : RepositoryBase<VIEW_MEMBER_ORG>, IVIEW_MEMBER_ORG_Repository
    {
        public VIEW_MEMBER_ORG_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


