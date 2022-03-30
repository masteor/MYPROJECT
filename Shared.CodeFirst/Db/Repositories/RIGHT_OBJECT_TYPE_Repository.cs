using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRIGHT_OBJECT_TYPE_Repository : IRepository<RIGHT_OBJECT_TYPE>
    {

    }
    public class RIGHT_OBJECT_TYPE_Repository : RepositoryBase<RIGHT_OBJECT_TYPE>, IRIGHT_OBJECT_TYPE_Repository 
    {
        public RIGHT_OBJECT_TYPE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}