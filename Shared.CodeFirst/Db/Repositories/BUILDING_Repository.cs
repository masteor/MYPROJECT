using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IBUILDING_Repository : IRepository<BUILDING>
    {

    }
    public class BUILDING_Repository : RepositoryBase<BUILDING>, IBUILDING_Repository
    {
        public BUILDING_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
