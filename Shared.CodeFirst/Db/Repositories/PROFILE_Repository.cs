using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IPROFILE_Repository : IRepository<PROFILE>
    {

    }
    public class PROFILE_Repository : RepositoryBase<PROFILE>, IPROFILE_Repository
    {
        public PROFILE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
