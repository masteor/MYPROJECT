using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface INOTIFY_SUB_Repository : IRepository<NOTIFY_SUB>
    {

    }
    public class NOTIFY_SUB_Repository : RepositoryBase<NOTIFY_SUB>, INOTIFY_SUB_Repository
    {
        public NOTIFY_SUB_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
