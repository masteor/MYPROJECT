using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_OBJECT_USER_RIGHTS_Repository : IRepository<VIEW_OBJECT_USER_RIGHTS>
    {
        
    }
        
    public class VIEW_OBJECT_USER_RIGHTS_Repository : RepositoryBase<VIEW_OBJECT_USER_RIGHTS>, IVIEW_OBJECT_USER_RIGHTS_Repository
    {
        public VIEW_OBJECT_USER_RIGHTS_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}