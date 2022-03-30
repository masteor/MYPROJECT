using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Services.GetAll.Таблицы
{
    /// <summary>
    /// Сначала проверяем маппинги - правильно ли они созданы, на те ли поля они смотрят
    /// это проверяется через процедуру GetAll - самое главное тут отправка SQL запроса,
    /// а не то, что он вернет
    /// </summary>
    [TestFixture]
    public class RESOURCE_RepositoryTests : Init
    {
        /// <summary>
        /// настройка 
        /// </summary>
        private static RESOURCE_Repository Setup()
        {
            return new RESOURCE_Repository(DB_FACTORY);
        }

        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();

// действие
            TestDelegate testDelegate = () => repository.GetAll().ToList();
            var all = repository
                .GetMany(r => true)
                .ToList	();

            // утверждение
            Assert.DoesNotThrow(testDelegate);
//            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_SqlQuery_Procedure_GET_RESOURCES()
        {
            // подготовка
            var repository = Setup();
            List<RESOURCE>? all = null;
            
            // действие
            void TestDelegate()
                => all = repository
                    .GetContext()
                    .RESOURCE
                    .SqlQuery($"select * from GET_RESOURCES()")
                    .ToList();

            // утверждение

            Assert.DoesNotThrow(TestDelegate);
            // Assert.IsNotEmpty(all);
        }
    }
}
