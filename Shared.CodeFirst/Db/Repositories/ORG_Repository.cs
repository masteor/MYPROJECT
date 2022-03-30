using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IORG_Repository : IRepository<ORG>
    {

    }
    public class ORG_Repository : RepositoryBase<ORG>, IORG_Repository
    {
        public ORG_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
