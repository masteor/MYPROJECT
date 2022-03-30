using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_EMPLOYEE_EXT_Repository : IRepository<VIEW_EMPLOYEE_EXT>
    {
    }
    public class VIEW_EMPLOYEE_EXT_Repository : RepositoryBase<VIEW_EMPLOYEE_EXT>, IVIEW_EMPLOYEE_EXT_Repository
    {
        public VIEW_EMPLOYEE_EXT_Repository (IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}