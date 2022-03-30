using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_REPORT_RESOURCES_WHERE_AM_I_Repository : IRepository<VIEW_REPORT_RESOURCES_WHERE_AM_I>
    {

    }

    public class VIEW_REPORT_RESOURCES_WHERE_AM_I_Repository : RepositoryBase<VIEW_REPORT_RESOURCES_WHERE_AM_I>, IVIEW_REPORT_RESOURCES_WHERE_AM_I_Repository
    {
        public VIEW_REPORT_RESOURCES_WHERE_AM_I_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


