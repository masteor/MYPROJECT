
 






/*
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Repositories\ATTRI_Repository.cs
*/

// @LABEL:Repositories@

using QWERTY.Shared.Db.Entities.Системные_таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface IATTRI_Repository : IRepository<ATTRI>
    {

    }

    public class ATTRI_Repository : RepositoryBase<ATTRI>, IATTRI_Repository
    {
        public ATTRI_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


