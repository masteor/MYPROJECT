using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRIGHT_GROUP_Repository : IRepository<RIGHT_GROUP>
    {

    }
    public class RIGHT_GROUP_Repository : RepositoryBase<RIGHT_GROUP>, IRIGHT_GROUP_Repository
    {
        public RIGHT_GROUP_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
