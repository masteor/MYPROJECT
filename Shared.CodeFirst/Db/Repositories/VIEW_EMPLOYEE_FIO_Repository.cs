using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_EMPLOYEE_FIO_Repository : IRepository<VIEW_EMPLOYEE_FIO>
    {

    }

    public class VIEW_EMPLOYEE_FIO_Repository : RepositoryBase<VIEW_EMPLOYEE_FIO>, IVIEW_EMPLOYEE_FIO_Repository
    {
        public VIEW_EMPLOYEE_FIO_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


