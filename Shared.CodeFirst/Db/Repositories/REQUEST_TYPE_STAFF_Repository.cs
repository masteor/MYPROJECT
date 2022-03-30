using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IREQUEST_TYPE_STAFF_Repository : IRepository<REQUEST_TYPE_STAFF>
    {

    }
    public class REQUEST_TYPE_STAFF_Repository : RepositoryBase<REQUEST_TYPE_STAFF>, IREQUEST_TYPE_STAFF_Repository
    {
        public REQUEST_TYPE_STAFF_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
