using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface ISERVICE_Repository : IRepository<SERVICE>
    {

    }
    public class SERVICE_Repository : RepositoryBase<SERVICE>, ISERVICE_Repository
    {
        public SERVICE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
