using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Прочие
{
    [TestFixture]
    public class DatabaseExist : Init
    {
        [Test]
        public void TEST_DB_EXIST()
        {
            /*var dbFactory = new DbFactory($"DataSource=TEST2;UserID=1;Password={string.Empty};PersistSecurityInfo=True;MinimumPoolSize=5");*/
            /*var dbFactory = DB_FACTORY;
            dbFactory.Init();
            var dbContext = dbFactory.GET_DB_CONTEXT;
            var dbExist = dbContext.Database.Exists();
            Assert.IsTrue(dbExist);*/
        }
    }
}