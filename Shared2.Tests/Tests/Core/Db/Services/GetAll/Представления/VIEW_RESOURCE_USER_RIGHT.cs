using System.Linq;
using DBPSA.Shared.Db.Repositories;
using DBPSA.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Db.Services.GetAll.Представления
{
    [TestFixture]
    public class VIEW_RESOURCE_USER_RIGHT : Init
    {
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            // действие
            TestDelegate testDelegate = () => repository.GetAll().ToList();
            var all = repository.GetAll().ToList	();
            // утверждение
            Assert.DoesNotThrow(testDelegate);
            Assert.IsNotEmpty(all);
        }

        private static VIEW_RESOURCE_USER_RIGHT_Repository Setup() => new VIEW_RESOURCE_USER_RIGHT_Repository(DB_FACTORY);
    }
}