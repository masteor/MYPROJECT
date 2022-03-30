using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IRESOURCE_MEMBERS_Repository : IRepository<RESOURCE_MEMBER>
    {

    }

    public class RESOURCE_MEMBERS_Repository : RepositoryBase<RESOURCE_MEMBER>, IRESOURCE_MEMBERS_Repository
    {
        public RESOURCE_MEMBERS_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


