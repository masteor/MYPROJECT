using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRIGHT_Repository : IRepository<RIGHT>
    {

    }
    public class RIGHT_Repository : RepositoryBase<RIGHT>, IRIGHT_Repository
    {
        public RIGHT_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
