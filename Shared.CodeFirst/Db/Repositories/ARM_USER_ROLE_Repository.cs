using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IARM_USER_ROLE_Repository : IRepository<ARM_USER_ROLE>
    {

    }
    public class ARM_USER_ROLE_Repository : RepositoryBase<ARM_USER_ROLE>, IARM_USER_ROLE_Repository
    {
        public ARM_USER_ROLE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
