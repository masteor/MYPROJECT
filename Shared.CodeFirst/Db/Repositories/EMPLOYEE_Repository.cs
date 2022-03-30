using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IEMPLOYEE_Repository : IRepository<EMPLOYEE>
    {
        
    }

    public class EMPLOYEE_Repository : RepositoryBase<EMPLOYEE>, IEMPLOYEE_Repository
    {
        public EMPLOYEE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }

        //public EMPLOYEE GetByLogin(string login)
        //{
        //    login = login.ToLower();
        //    /* todo: заглушка, исправить*/
        //    /*return Найти(e => e.Login == login);*/
        //    return Найти(e => e.TNUM == 99515);
        //}

/*        public EMPLOYEE GetByEmail(string email)
        {
            email = email.ToLower();
            return Найти(e => e. == email);
        }*/
    }
}
