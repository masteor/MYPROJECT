using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IDOC_Repository : IRepository<DOC>
    {

    }
    public class DOC_Repository : RepositoryBase<DOC>, IDOC_Repository
    {
        public DOC_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
