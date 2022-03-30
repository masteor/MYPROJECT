using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRESOURCE_UCA_Repository : IRepository<RESOURCE_UCA>
    {

    }
    public class RESOURCE_UCA_Repository : RepositoryBase<RESOURCE_UCA>, IRESOURCE_UCA_Repository
    {
        public RESOURCE_UCA_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
