
 







/*
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Repositories\VIEW_PROFILE_Repository.cs
*/

// @LABEL:Repositories@

using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_PROFILE_Repository : IRepository<VIEW_PROFILE>
    {

    }

    public class VIEW_PROFILE_Repository : RepositoryBase<VIEW_PROFILE>, IVIEW_PROFILE_Repository
    {
        public VIEW_PROFILE_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


