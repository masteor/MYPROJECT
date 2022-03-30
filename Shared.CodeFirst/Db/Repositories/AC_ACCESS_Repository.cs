using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IAC_ACCESS_Repository : IRepository<AC_ACCESS>
    {

    }
    public class AC_ACCESS_Repository : RepositoryBase<AC_ACCESS>, IAC_ACCESS_Repository
    {
        public AC_ACCESS_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}