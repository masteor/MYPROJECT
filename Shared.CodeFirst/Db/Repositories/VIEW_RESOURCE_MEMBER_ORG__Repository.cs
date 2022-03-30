using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_RESOURCE_MEMBER_ORG_Repository : IRepository<VIEW_RESOURCE_MEMBER_ORG>
    {

    }

    public class VIEW_RESOURCE_MEMBER_ORG_Repository : RepositoryBase<VIEW_RESOURCE_MEMBER_ORG>, IVIEW_RESOURCE_MEMBER_ORG_Repository
    {
        public VIEW_RESOURCE_MEMBER_ORG_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


