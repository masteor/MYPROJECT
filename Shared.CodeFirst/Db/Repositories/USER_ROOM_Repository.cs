using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IUSER_ROOM_Repository : IRepository<USER_ROOM>
    {

    }
    public class USER_ROOM_Repository : RepositoryBase<USER_ROOM>, IUSER_ROOM_Repository
    {
        public USER_ROOM_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
