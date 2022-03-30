using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_RESOURCE_Repository : IRepository<VIEW_RESOURCE>
    {

    }

    public class VIEW_RESOURCE_Repository : RepositoryBase<VIEW_RESOURCE>, IVIEW_RESOURCE_Repository
    {
        public VIEW_RESOURCE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


