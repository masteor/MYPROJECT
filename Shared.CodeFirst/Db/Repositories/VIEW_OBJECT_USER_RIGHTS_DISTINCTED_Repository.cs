using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_OBJECT_USER_RIGHTS_DISTINCTED_Repository : IRepository<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>
    {
    }
        
    public class VIEW_OBJECT_USER_RIGHTS_DISTINCTED_Repository : RepositoryBase<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>, IVIEW_OBJECT_USER_RIGHTS_DISTINCTED_Repository 
    {
        public VIEW_OBJECT_USER_RIGHTS_DISTINCTED_Repository (IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}