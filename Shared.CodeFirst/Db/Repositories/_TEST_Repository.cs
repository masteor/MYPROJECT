using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface ITest_Repository : IRepository<TEST>
    {
        
    }

    public class TEST_Repository : RepositoryBase<TEST>, ITest_Repository
    {
        public TEST_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}