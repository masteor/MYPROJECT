using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IFORM_PERM_Repository : IRepository<FORM_PERM>
    {

    }
    public class FORM_PERM_Repository : RepositoryBase<FORM_PERM>, IFORM_PERM_Repository
    {
        public FORM_PERM_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
