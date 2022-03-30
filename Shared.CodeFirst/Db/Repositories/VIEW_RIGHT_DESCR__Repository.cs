using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_RIGHT_DESCR_Repository : IRepository<VIEW_RIGHT_DESCR>
    {

    }

    public class VIEW_RIGHT_DESCR_Repository : RepositoryBase<VIEW_RIGHT_DESCR>, IVIEW_RIGHT_DESCR_Repository
    {
        public VIEW_RIGHT_DESCR_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


