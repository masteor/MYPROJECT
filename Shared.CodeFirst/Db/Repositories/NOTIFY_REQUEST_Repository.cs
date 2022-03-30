using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface INOTIFY_REQUEST_Repository : IRepository<NOTIFY_REQUEST>
    {

    }
    public class NOTIFY_REQUEST_Repository : RepositoryBase<NOTIFY_REQUEST>, INOTIFY_REQUEST_Repository
    {
        public NOTIFY_REQUEST_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
