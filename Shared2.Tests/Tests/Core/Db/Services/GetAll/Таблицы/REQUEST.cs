using System;
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
    public class REQUEST_RepositoryTests : Init
    {
        /// <summary>
        /// настройка 
        /// </summary>
        private static REQUEST_Repository Setup()
        {
            return new REQUEST_Repository(DB_FACTORY);
        }

        /// <summary>
        /// проверяем маппинги, тут главное чтобы прошел SQL запрос, без исключений, значения НЕ проверяются
        /// </summary>
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
            Assert.IsNotEmpty(all);
        }
        
        
            
        [Test]
        public void TEST_SqlQuery_Procedure_GET_REQUESTS()
        {
            // подготовка
            var repository = Setup();
            List<REQUEST>? all = null;
            
            // действие
            void TestDelegate()
                => all = repository
                    .GetContext()
                    .REQUEST
                    .SqlQuery($"select * from GET_REQUESTS()")
                    .ToList();

            // утверждение

            Assert.DoesNotThrow(TestDelegate);
            // Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_ADD()
        {
            // подготовка
            var repository = Setup();
            REQUEST request = new REQUEST
            {
                id = 0,
                id_request_type = 1,
                date_1 = DateTime.Now,
                date_2 = null,
                id_user_1 = 1,
                id_user_2 = 1,
                id_request_state = 1,
                id_doc = null,
                reg_num = string.Empty,
                parent = null
            };

            repository.Создать(request);
            repository.Коммитнуть();
            
            Assert.Pass();
        }
    }
}
