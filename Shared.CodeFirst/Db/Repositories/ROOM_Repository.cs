using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IROOM_Repository : IRepository<ROOM>
    {

    }
    public class ROOM_Repository : RepositoryBase<ROOM>, IROOM_Repository
    {
        public ROOM_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
