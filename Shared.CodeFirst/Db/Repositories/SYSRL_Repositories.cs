
 






/*
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Repositories\SYSRL_Repository.cs
*/

// @LABEL:Repositories@

using QWERTY.Shared.Db.Entities.Системные_таблицы;
using QWERTY.Shared.Db.Infrastructure;

namespace QWERTY.Shared.Db.Repositories
{
    public interface ISYSRL_Repository : IRepository<SYSRL>
    {

    }

    public class SYSRL_Repository : RepositoryBase<SYSRL>, ISYSRL_Repository
    {
        public SYSRL_Repository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


