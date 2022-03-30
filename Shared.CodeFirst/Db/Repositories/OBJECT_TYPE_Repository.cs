using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IOBJECT_TYPE_Repository : IRepository<OBJECT_TYPE>
    {

    }
    public class OBJECT_TYPE_Repository : RepositoryBase<OBJECT_TYPE>, IOBJECT_TYPE_Repository
    {
        public OBJECT_TYPE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
