using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IREQUEST_STATE_Repository : IRepository<REQUEST_STATE>
    {

    }
    public class REQUEST_STATE_Repository : RepositoryBase<REQUEST_STATE>, IREQUEST_STATE_Repository
    {
        public REQUEST_STATE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
