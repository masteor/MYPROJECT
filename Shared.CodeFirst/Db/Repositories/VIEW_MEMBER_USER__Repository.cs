using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_MEMBER_USER_Repository : IRepository<VIEW_MEMBER_USER>
    {

    }

    public class VIEW_MEMBER_USER_Repository : RepositoryBase<VIEW_MEMBER_USER>, IVIEW_MEMBER_USER_Repository
    {
        public VIEW_MEMBER_USER_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


