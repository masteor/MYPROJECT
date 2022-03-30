
 







/*
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Repositories\VIEW_FIO_Repository.cs
*/

// @LABEL:Repositories@

using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IVIEW_FIO_Repository : IRepository<VIEW_FIO>
    {

    }

    public class VIEW_FIO_Repository : RepositoryBase<VIEW_FIO>, IVIEW_FIO_Repository
    {
        public VIEW_FIO_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


