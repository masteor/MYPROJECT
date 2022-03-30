using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRESOURCE_RESP_Repository : IRepository<RESOURCE_RESP>
    {

    }
    public class RESOURCE_RESP_Repository : RepositoryBase<RESOURCE_RESP>, IRESOURCE_RESP_Repository
    {
        public RESOURCE_RESP_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
