using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IUCA_LIST_Repository : IRepository<UCA_LIST>
    {

    }
    public class UCA_LIST_Repository : RepositoryBase<UCA_LIST>, IUCA_LIST_Repository
    {
        public UCA_LIST_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
