using System.Linq;
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
    public class NOTIFY_REQUEST_RepositoryTests : Init
    {
        /// <summary>
        /// настройка 
        /// </summary>
        private static NOTIFY_REQUEST_Repository Setup()
        {
            return new NOTIFY_REQUEST_Repository(DB_FACTORY);
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
            Assert.IsNotEmpty(all);
        }
    }
}
