using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface ISTAFF_UNIT_Repository : IRepository<STAFF_UNIT>
    {

    }
    public class STAFF_UNIT_Repository : RepositoryBase<STAFF_UNIT>, ISTAFF_UNIT_Repository
    {
        public STAFF_UNIT_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
