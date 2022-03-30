using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_REPORT_ALL_RESOURCES_Repository : IRepository<VIEW_REPORT_ALL_RESOURCES>
    {

    }

    public class VIEW_REPORT_ALL_RESOURCES_Repository : RepositoryBase<VIEW_REPORT_ALL_RESOURCES>, IVIEW_REPORT_ALL_RESOURCES_Repository
    {
        public VIEW_REPORT_ALL_RESOURCES_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


