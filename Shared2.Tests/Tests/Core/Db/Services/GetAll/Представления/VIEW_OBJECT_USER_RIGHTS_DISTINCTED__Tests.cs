using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Services.GetAll.Представления
{
    [TestFixture]
    public class VIEW_OBJECT_USER_RIGHTS_DISTINCTED__Tests : Init
    {
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            // действие
            TestDelegate testDelegate = () => repository
                .GetMany(v => true)
                .ToList();
            var all = repository.GetAll().ToList();
            // утверждение
            Assert.DoesNotThrow(testDelegate);
//            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_SqlQuery__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            List<VIEW_OBJECT_USER_RIGHTS_DISTINCTED>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewObjectUserRightsDistincted
                    .SqlQuery($"select * from {ИмяТаблицы.VIEW_OBJECT_USER_RIGHTS_DISTINCT} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
//            Assert.IsNotEmpty(all);
        }

        private static VIEW_OBJECT_USER_RIGHTS_DISTINCTED_Repository Setup() => new VIEW_OBJECT_USER_RIGHTS_DISTINCTED_Repository(DB_FACTORY);
    }
}