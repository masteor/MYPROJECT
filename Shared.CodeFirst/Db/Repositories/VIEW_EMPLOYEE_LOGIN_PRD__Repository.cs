using DBPSA.Shared.Db.Entities.Представления;
using DBPSA.Shared.Db.Infrastructure;

namespace DBPSA.Shared.Db.Repositories
{
    public interface IVIEW_EMPLOYEE_LOGIN_PRD__Repository : IRepository<VIEW_EMPLOYEE_LOGIN_PRD>
    {

    }

    public class VIEW_EMPLOYEE_LOGIN_PRD_Repository : RepositoryBase<VIEW_EMPLOYEE_LOGIN_PRD>, IVIEW_EMPLOYEE_LOGIN_PRD__Repository
    {
        public VIEW_EMPLOYEE_LOGIN_PRD_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


