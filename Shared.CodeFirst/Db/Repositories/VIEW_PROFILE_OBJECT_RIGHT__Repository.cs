using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_PROFILE_OBJECT_RIGHT_Repository : IRepository<VIEW_PROFILE_OBJECT_RIGHT>
    {

    }

    public class _VIEW_PROFILE_OBJECT_RIGHT_Repository : RepositoryBase<VIEW_PROFILE_OBJECT_RIGHT>, IVIEW_PROFILE_OBJECT_RIGHT_Repository
    {
        public _VIEW_PROFILE_OBJECT_RIGHT_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


