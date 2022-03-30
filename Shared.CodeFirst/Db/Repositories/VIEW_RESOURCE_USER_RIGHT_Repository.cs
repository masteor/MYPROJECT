using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_RESOURCE_USER_RIGHT_Repository : IRepository<VIEW_RESOURCE_USER_RIGHT>
    {
        
    }
    
    public class VIEW_RESOURCE_USER_RIGHT_Repository : RepositoryBase<VIEW_RESOURCE_USER_RIGHT>, IVIEW_RESOURCE_USER_RIGHT_Repository
    {
        public VIEW_RESOURCE_USER_RIGHT_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}