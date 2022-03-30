using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IPROM_AREA_Repository : IRepository<PROM_AREA>
    {

    }
    public class PROM_AREA_Repository : RepositoryBase<PROM_AREA>, IPROM_AREA_Repository
    {
        public PROM_AREA_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
