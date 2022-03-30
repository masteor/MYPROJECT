using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IARM_USER_Repository : IRepository<ARM_USER>
    {

    }
    public class ARM_USER_Repository : RepositoryBase<ARM_USER>, IARM_USER_Repository
    {
        public ARM_USER_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
