using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_RESOURCE_EXT_Repository : IRepository<VIEW_RESOURCE_EXT>
    {
    }
    public class VIEW_RESOURCE_EXT_Repository : RepositoryBase<VIEW_RESOURCE_EXT>, IVIEW_RESOURCE_EXT_Repository
    {
        public VIEW_RESOURCE_EXT_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
