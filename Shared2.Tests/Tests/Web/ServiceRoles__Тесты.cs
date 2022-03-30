using QWERTY.Web.Core.Authentication;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Web
{
    [TestFixture]
    public class ServiceRoles__Тесты
    {
        [Test]
        public void НетРолей__ВозвращаетНетПривилегий()
        {
            var rolesForUser = new string[] { };
            var isPrivileged = ServiceRoles.IsPrivileged(rolesForUser);
            
            Assert.IsFalse(isPrivileged);
        }
        
        [Test]
        public void ОднаРольБезПривилегий__ВозвращаетНетПривилегий()
        {
            var rolesForUser = new string[] { ServiceRoles.Anonim };
            var isPrivileged = ServiceRoles.IsPrivileged(rolesForUser);
            
            Assert.IsFalse(isPrivileged);
        }
        
        [Test]
        public void НесколькоРолейБезПривилегий__ВозвращаетНетПривилегий()
        {
            var rolesForUser = new string[] { ServiceRoles.Anonim, ServiceRoles.Operator };
            var isPrivileged = ServiceRoles.IsPrivileged(rolesForUser);
            
            Assert.IsFalse(isPrivileged);
        }
        
        [Test]
        public void ОднаИзРолейСоПривилегией__ВозвращаетЕстьПривилегия()
        {
            var rolesForUser = new string[] { ServiceRoles.Anonim, ServiceRoles.Operator, ServiceRoles.Executor };
            var isPrivileged = ServiceRoles.IsPrivileged(rolesForUser);
            
            Assert.IsTrue(isPrivileged);
        }
    }
}