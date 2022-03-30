
 







/*
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Repositories\VIEW_EMPLOYEE_Repository.cs
*/

// @LABEL:Repositories@

using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_EMPLOYEE_Repository : IRepository<VIEW_EMPLOYEE>
    {

    }

    public class VIEW_EMPLOYEE_Repository : RepositoryBase<VIEW_EMPLOYEE>, IVIEW_EMPLOYEE_Repository
    {
        public VIEW_EMPLOYEE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


