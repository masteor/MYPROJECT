using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRIGHT_DESCRIPTION_Repository : IRepository<RIGHT_DESCR>
    {

    }
    public class RIGHT_DESCRIPTION_Repository : RepositoryBase<RIGHT_DESCR>, IRIGHT_DESCRIPTION_Repository
    {
        public RIGHT_DESCRIPTION_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
