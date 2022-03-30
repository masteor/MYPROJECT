using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface ISTAFF_Repository : IRepository<STAFF>
    {

    }
    public class STAFF_Repository : RepositoryBase<STAFF>, ISTAFF_Repository
    {
        public STAFF_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
