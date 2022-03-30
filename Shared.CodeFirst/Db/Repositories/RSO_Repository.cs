using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRSO_Repository : IRepository<RSO>
    {

    }
    public class RSO_Repository : RepositoryBase<RSO>, IRSO_Repository
    {
        public RSO_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
