using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_RESOURCES_BY_OT_ST_Repository : IRepository<VIEW_RESOURCES_BY_OT_ST>
    {

    }

    public class VIEW_RESOURCES_BY_OT_ST_Repository : RepositoryBase<VIEW_RESOURCES_BY_OT_ST>, IVIEW_RESOURCES_BY_OT_ST_Repository
    {
        public VIEW_RESOURCES_BY_OT_ST_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


