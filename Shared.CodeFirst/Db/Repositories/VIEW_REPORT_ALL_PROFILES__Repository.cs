using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_REPORT_ALL_PROFILES_Repository : IRepository<VIEW_REPORT_ALL_PROFILES>
    {

    }

    public class VIEW_REPORT_ALL_PROFILES_Repository : RepositoryBase<VIEW_REPORT_ALL_PROFILES>, IVIEW_REPORT_ALL_PROFILES_Repository
    {
        public VIEW_REPORT_ALL_PROFILES_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


