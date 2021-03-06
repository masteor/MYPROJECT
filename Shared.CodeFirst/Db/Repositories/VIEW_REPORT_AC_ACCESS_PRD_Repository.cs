using DBPSA.Shared.Db.Entities.Представления;
using DBPSA.Shared.Db.Infrastructure;

namespace DBPSA.Shared.Db.Repositories
{
    public interface IVIEW_REPORT_AC_ACCESS_PRD_Repository : IRepository<VIEW_REPORT_AC_ACCESS_PRD>
    {

    }

    public class VIEW_REPORT_AC_ACCESS_PRD_Repository :
        RepositoryBase<VIEW_REPORT_AC_ACCESS_PRD>,
        IVIEW_REPORT_AC_ACCESS_PRD_Repository
    {
        public VIEW_REPORT_AC_ACCESS_PRD_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}