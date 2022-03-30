using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IREQUEST_TYPE_Repository : IRepository<REQUEST_TYPE>
    {

    }
    public class REQUEST_TYPE_Repository : RepositoryBase<REQUEST_TYPE>, IREQUEST_TYPE_Repository
    {
        public REQUEST_TYPE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
