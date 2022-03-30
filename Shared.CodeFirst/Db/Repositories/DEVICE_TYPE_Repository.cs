using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IDEVICE_TYPE_Repository : IRepository<DEVICE_TYPE>
    {

    }
    public class DEVICE_TYPE_Repository : RepositoryBase<DEVICE_TYPE>, IDEVICE_TYPE_Repository
    {
        public DEVICE_TYPE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
