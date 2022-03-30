
 







/*
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Repositories\VIEW_EMPLOYEE_LOGIN_Repository.cs
*/

// @LABEL:Repositories@

using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_EMPLOYEE_LOGIN_Repository : IRepository<VIEW_EMPLOYEE_LOGIN>
    {

    }

    public class VIEW_EMPLOYEE_LOGIN_Repository : RepositoryBase<VIEW_EMPLOYEE_LOGIN>, IVIEW_EMPLOYEE_LOGIN_Repository
    {
        public VIEW_EMPLOYEE_LOGIN_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


