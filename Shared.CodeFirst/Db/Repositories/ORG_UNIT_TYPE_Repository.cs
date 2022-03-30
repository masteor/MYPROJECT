using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IORG_UNIT_TYPE_Repository : IRepository<ORG_UNIT_TYPE>
    {

    }
    public class ORG_UNIT_TYPE_Repository : RepositoryBase<ORG_UNIT_TYPE>, IORG_UNIT_TYPE_Repository
    {
        public ORG_UNIT_TYPE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
