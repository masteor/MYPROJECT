using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IDEVICE_Repository : IRepository<DEVICE>
    {

    }
    public class DEVICE_Repository : RepositoryBase<DEVICE>, IDEVICE_Repository
    {
        public DEVICE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
