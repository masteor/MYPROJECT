using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface ILOGIN_Repository : IRepository<LOGIN>
    {

    }
    public class LOGIN_Repository : RepositoryBase<LOGIN>, ILOGIN_Repository
    {
        public LOGIN_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
