using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IAC_FRAGMENT_Repository : IRepository<AC_FRAGMENT>
    {

    }
    public class AC_FRAGMENT_Repository : RepositoryBase<AC_FRAGMENT>, IAC_FRAGMENT_Repository
    {
        public AC_FRAGMENT_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
