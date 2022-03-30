using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_REPORT_RSD_Repository : IRepository<VIEW_REPORT_RSD>
    {

    }

    public class VIEW_REPORT_RSD_Repository : RepositoryBase<VIEW_REPORT_RSD>, IVIEW_REPORT_RSD_Repository
    {
        public VIEW_REPORT_RSD_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


