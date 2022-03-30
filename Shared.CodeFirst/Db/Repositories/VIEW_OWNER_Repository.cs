
 







/*
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Repositories\VIEW_OWNER_Repository.cs
*/

// @LABEL:Repositories@

using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_OWNER_Repository : IRepository<VIEW_OWNER>
    {

    }

    public class VIEW_OWNER_Repository : RepositoryBase<VIEW_OWNER>, IVIEW_OWNER_Repository
    {
        public VIEW_OWNER_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


