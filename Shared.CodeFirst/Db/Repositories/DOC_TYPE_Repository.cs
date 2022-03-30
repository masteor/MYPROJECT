using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IDOC_TYPE_Repository : IRepository<DOC_TYPE>
    {

    }
    public class DOC_TYPE_Repository : RepositoryBase<DOC_TYPE>, IDOC_TYPE_Repository
    {
        public DOC_TYPE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
