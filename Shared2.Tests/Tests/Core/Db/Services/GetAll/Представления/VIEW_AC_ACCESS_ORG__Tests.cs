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
    public class VIEW_AC_ACCESS_ORG__Tests : Init
    {
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            // действие
            TestDelegate testDelegate = () => repository.GetAll().ToList();
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
            List<VIEW_AC_ACCESS_ORG>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewAcAccessOrgs
                    .SqlQuery($"select * from {ИмяТаблицы.ViewAcAccessOrg} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
//            Assert.IsNotEmpty(all);
        }

        private static VIEW_AC_ACCESS_ORG_Repository Setup() => new VIEW_AC_ACCESS_ORG_Repository(DB_FACTORY);
    }
}