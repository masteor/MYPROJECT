using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IFIO_Repository : IRepository<FIO>
    {

    }
    public class FIO_Repository : RepositoryBase<FIO>, IFIO_Repository
    {
        public FIO_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
