using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRESOURCE_Repository : IRepository<RESOURCE>
    {

    }
    public class RESOURCE_Repository : RepositoryBase<RESOURCE>, IRESOURCE_Repository
    {
        public RESOURCE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
