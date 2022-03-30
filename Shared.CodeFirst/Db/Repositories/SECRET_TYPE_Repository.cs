using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface ISECRET_TYPE_Repository : IRepository<SECRET_TYPE>
    {

    }
    public class SECRET_TYPE_Repository : RepositoryBase<SECRET_TYPE>, ISECRET_TYPE_Repository
    {
        public SECRET_TYPE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
