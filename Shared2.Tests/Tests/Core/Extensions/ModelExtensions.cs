using System;
using NUnit.Framework;
using Ext = QWERTY.Web.Core.Extensions.ModelExtensions;

namespace QWERTY.Shared2.Tests.Tests.Core.Extensions
{
    [TestFixture]
    public class ModelExtensions
    {
        [Test]
        public void Метод_ЗапарситьДату_на_различных_значениях_не_кидает_исключение_возвращает_корректную_дату()
        {
            // на нулл возвращает нулл
            Assert.AreEqual(Ext.ЗапарситьДату(null), null);
            
            // добирает дату до конца суток
            Assert.AreEqual(Ext.ЗапарситьДату("01.01.2000 0:00:00"), new DateTime(2000, 1,1,23,59,59));
            
            // не вызывает перелистывания даты
            Assert.AreEqual(Ext.ЗапарситьДату("01.01.2000 23:59:59"), new DateTime(2000, 1,1,23,59,59));
            
            // не вызывает перелистывания даты
            Assert.AreEqual(Ext.ЗапарситьДату("31.12.2000 23:59:59"), new DateTime(2000, 12,31,23,59,59));
            
            // не возвращает миллисекунды
            Assert.AreEqual(Ext.ЗапарситьДату("01.01.2000 0:00:00")!.Value.Millisecond, 0);
            
            // обрабатывает некорректные даты
            Assert.AreEqual(Ext.ЗапарситьДату("01.01.2000 1:23:45:567890"), null);
            
            // обрабатывает некорректные даты
            Assert.AreEqual(Ext.ЗапарситьДату(""), null);
            
            // обрабатывает некорректные даты
            Assert.AreEqual(Ext.ЗапарситьДату("привет"), null);
        }
    }
}