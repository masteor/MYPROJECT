using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IDIC_Repository : IRepository<DIC>
    {

    }
    public class DIC_Repository : RepositoryBase<DIC>, IDIC_Repository
    {
        public DIC_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}