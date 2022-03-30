using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_REPORT_AC_ACCESS_Repository : IRepository<VIEW_REPORT_AC_ACCESS>
    {

    }

    public class VIEW_REPORT_AC_ACCESS_Repository : RepositoryBase<VIEW_REPORT_AC_ACCESS>, 
        IVIEW_REPORT_AC_ACCESS_Repository
    {
        public VIEW_REPORT_AC_ACCESS_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
