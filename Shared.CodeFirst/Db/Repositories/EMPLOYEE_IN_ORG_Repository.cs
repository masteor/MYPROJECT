using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IEMPLOYEE_IN_ORG_Repository : IRepository<EMPLOYEE_IN_ORG>
    {

    }
    public class EMPLOYEE_IN_ORG_Repository : RepositoryBase<EMPLOYEE_IN_ORG>, IEMPLOYEE_IN_ORG_Repository
    {
        public EMPLOYEE_IN_ORG_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
