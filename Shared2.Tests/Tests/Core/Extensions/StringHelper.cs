using System.Collections.Generic;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Extensions
{
    [TestFixture]
    public class TestStringHelper
    {
        [Test]
        public void ПередаемМассивСлов__ПолучаемОднуСтрокуИзСлов()
        {
            IEnumerable<string>? sNull = null;
            Assert.AreEqual(sNull.Print("\n"), "<пустой список>");
            
            Assert.AreEqual(new[] {""}.Print("\n"), "<empty>\n");
            Assert.AreEqual(new[] {string.Empty}.Print("\n"), "<empty>\n");
            Assert.AreEqual(new string[] {null}.Print("\n"), "<null>\n");
            Assert.AreEqual(new[] {"one"}.Print("\n"), "one\n");
            
            Assert.AreEqual(new[] {"one", "two"}.Print("\n"), "one\ntwo\n");    
            Assert.AreEqual(new[] {null, "two"}.Print("\n"), "<null>\ntwo\n");    
            Assert.AreEqual(new[] {"one", null}.Print("\n"), "one\n<null>\n");
            Assert.AreEqual(new[] {string.Empty, "two"}.Print("\n"), "<empty>\ntwo\n");    
            Assert.AreEqual(new[] {"two", string.Empty}.Print("\n"), "two\n<empty>\n");
        }
    }
}
