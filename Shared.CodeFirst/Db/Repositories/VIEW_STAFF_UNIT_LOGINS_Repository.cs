
 







/*
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Repositories\VIEW_STAFF_UNIT_LOGINS_Repository.cs
*/

// @LABEL:Repositories@

using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_STAFF_UNIT_LOGINS_Repository : IRepository<VIEW_STAFF_UNIT_LOGINS>
    {

    }

    public class VIEW_STAFF_UNIT_LOGINS_Repository : RepositoryBase<VIEW_STAFF_UNIT_LOGINS>, IVIEW_STAFF_UNIT_LOGINS_Repository
    {
        public VIEW_STAFF_UNIT_LOGINS_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


