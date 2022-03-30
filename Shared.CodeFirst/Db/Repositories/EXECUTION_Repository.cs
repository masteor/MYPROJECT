using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IEXECUTION_Repository : IRepository<EXECUTION>
    {

    }
    public class EXECUTION_Repository : RepositoryBase<EXECUTION>, IEXECUTION_Repository
    {
        public EXECUTION_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
