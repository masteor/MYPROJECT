using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IOBJECT_Repository : IRepository<OBJECT>
    {

    }
    public class OBJECT_Repository : RepositoryBase<OBJECT>, IOBJECT_Repository
    {
        public OBJECT_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
