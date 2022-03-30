using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IMEMBER_Repository : IRepository<MEMBER>
    {

    }
    public class MEMBER_Repository : RepositoryBase<MEMBER>, IMEMBER_Repository
    {
        public MEMBER_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
