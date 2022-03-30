using DBPSA.Shared.Db.Repositories;
using NUnit.Framework;

namespace DBPSA.Shared.Tests.Core.Db.Services
{
    [TestFixture]
    public class __DIC : Init
    {
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();

            // действие
            TestDelegate testDelegate = () => repository.GetAll();

            // утверждение
            Assert.DoesNotThrow(testDelegate);
        }

        private static DIC_Repository Setup()
        {
            return new DIC_Repository(DB_FACTORY);
        }
    }
}