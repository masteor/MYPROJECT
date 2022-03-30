using QWERTY.Shared.Db.Infrastructure;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;

namespace QWERTY.Shared2.Tests.Tests.Core.Db
{
    public class Setup : Init
    {
        public static TSource GetRepository<TSource>(DbFactory dbFactory) where TSource : new()
        {
            return new TSource();
        }    
    }
}