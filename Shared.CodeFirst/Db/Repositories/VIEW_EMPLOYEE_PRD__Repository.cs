using DBPSA.Shared.Db.Entities.Представления;
using DBPSA.Shared.Db.Infrastructure;

namespace DBPSA.Shared.Db.Repositories
{
    public interface IVIEW_EMPLOYEE_PRD__Repository : IRepository<VIEW_EMPLOYEE_PRD>
    {

    }

    public class VIEW_EMPLOYEE_PRD__Repository : RepositoryBase<VIEW_EMPLOYEE_PRD>, IVIEW_EMPLOYEE_PRD__Repository
    {
        public VIEW_EMPLOYEE_PRD__Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


