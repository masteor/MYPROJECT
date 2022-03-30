using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_AC_ACCESS_ORG_Repository : IRepository<VIEW_AC_ACCESS_ORG>
    {
        
    }
    
    public class VIEW_AC_ACCESS_ORG_Repository : RepositoryBase<VIEW_AC_ACCESS_ORG>, IVIEW_AC_ACCESS_ORG_Repository
    {
        public VIEW_AC_ACCESS_ORG_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}