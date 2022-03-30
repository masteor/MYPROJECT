using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface ISERVICE_TYPE_Repository : IRepository<SERVICE_TYPE>
    {

    }
    public class SERVICE_TYPE_Repository : RepositoryBase<SERVICE_TYPE>, ISERVICE_TYPE_Repository
    {
        public SERVICE_TYPE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
