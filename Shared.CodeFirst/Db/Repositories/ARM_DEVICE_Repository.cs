using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IARM_DEVICE_Repository : IRepository<ARM_DEVICE>
    {

    }
    public class ARM_DEVICE_Repository : RepositoryBase<ARM_DEVICE>, IARM_DEVICE_Repository
    {
        public ARM_DEVICE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
