using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IARM_Repository : IRepository<ARM>
    {

    }
    public class ARM_Repository : RepositoryBase<ARM>, IARM_Repository
    {
        public ARM_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
