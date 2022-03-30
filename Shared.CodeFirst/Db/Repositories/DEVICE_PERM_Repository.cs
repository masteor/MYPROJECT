using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IDEVICE_PERM_Repository : IRepository<DEVICE_PERM>
    {

    }
    public class DEVICE_PERM_Repository : RepositoryBase<DEVICE_PERM>, IDEVICE_PERM_Repository
    {
        public DEVICE_PERM_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
