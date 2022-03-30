using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_REPORT_ALL_REQUESTS_Repository : IRepository<VIEW_REPORT_ALL_REQUESTS>
    {

    }

    public class VIEW_REPORT_ALL_REQUESTS_Repository : RepositoryBase<VIEW_REPORT_ALL_REQUESTS>, IVIEW_REPORT_ALL_REQUESTS_Repository
    {
        public VIEW_REPORT_ALL_REQUESTS_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


