using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IJOB_Repository : IRepository<JOB>
    {

    }
    public class JOB_Repository : RepositoryBase<JOB>, IJOB_Repository
    {
        public JOB_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
