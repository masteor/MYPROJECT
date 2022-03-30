using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_RESOURCE_MEMBER_EMPLOYEE_Repository : IRepository<VIEW_RESOURCE_MEMBER_EMPLOYEE>
    {

    }

    public class VIEW_RESOURCE_MEMBER_EMPLOYEE_Repository : 
        RepositoryBase<VIEW_RESOURCE_MEMBER_EMPLOYEE>,
        IVIEW_RESOURCE_MEMBER_EMPLOYEE_Repository
    {
        public VIEW_RESOURCE_MEMBER_EMPLOYEE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


