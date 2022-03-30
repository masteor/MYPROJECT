using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IREQUEST_Repository : IRepository<REQUEST>
    {

    }
    public class REQUEST_Repository : RepositoryBase<REQUEST>, IREQUEST_Repository
    {
        public REQUEST_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
