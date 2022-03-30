using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_ARM_USER_Repository : IRepository<VIEW_ARM_USER>
    {

    }

    public class VIEW_ARM_USER_Repository : RepositoryBase<VIEW_ARM_USER>, IVIEW_ARM_USER_Repository
    {
        public VIEW_ARM_USER_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


