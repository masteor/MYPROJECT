using System;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core
{
    [TestFixture]
    public class ГенераторМоделей__Тесты
    {
        [Test]
        public void ПолучитьВалидныйЕмайл__Тест()
        {
            Assert.AreEqual(ГенераторМоделей.ПолучитьВалидныйЕмайл(-1), "1@sils.local");
            Assert.AreEqual(ГенераторМоделей.ПолучитьВалидныйЕмайл(0),  "1@sils.local");
            
           Assert.AreEqual(ГенераторМоделей.ПолучитьВалидныйЕмайл(1),  "1@sils.local");
            Assert.AreEqual(ГенераторМоделей.ПолучитьВалидныйЕмайл("@sils.local".Length),  "1@sils.local");
            
            Assert.AreEqual(ГенераторМоделей.ПолучитьВалидныйЕмайл("1@sils.local".Length).Length, "1@sils.local".Length);
            
            Assert.AreEqual(ГенераторМоделей.ПолучитьВалидныйЕмайл("11234567890-=@sils.local".Length).Length, "11234567890-=@sils.local".Length);
            
            Assert.AreEqual(ГенераторМоделей.ПолучитьВалидныйЕмайл(Int32.MaxValue, "qwertyuiop"), "qwertyuiop@sils.local");
        }
    }
}