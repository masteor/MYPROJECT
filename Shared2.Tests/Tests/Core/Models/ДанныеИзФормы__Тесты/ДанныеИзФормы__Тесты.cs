using System;
using System.Collections.Generic;
using DBPSA.Shared.Models;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Models.ДанныеИзФормы__Тесты
{
    [TestFixture]
    public class ДанныеИзФормы__Тесты : ДанныеИзФормы
    {
        [Test]
        public void Метод_ДатаВалидна__Не_валидные_данные()
        {
            Assert.True(ДатаНЕвалидна(DateTime.MaxValue));
            Assert.True(!ДатаВалидна(DateTime.MaxValue));
            
            Assert.True(ДатаНЕвалидна(DateTime.MinValue));
            Assert.True(!ДатаВалидна(DateTime.MinValue));
            
            Assert.True(ДатаНЕвалидна(null));
            Assert.True(!ДатаВалидна(null));
            
            Assert.True(ДатаНЕвалидна(new DateTime(1999, 12, 31, 23, 59, 59)));
            Assert.True(!ДатаВалидна(new DateTime(1999, 12, 31, 23, 59, 59)));

            {
                var now = DateTime.Now;
                var lessNow = DateTime.Now.Add(new TimeSpan(0,0,1));
                Assert.True(ДатаНЕвалидна(lessNow));
                Assert.True(!ДатаВалидна(lessNow));
            }
        }
        
        [Test]
        public void Метод_ДатаВалидна__Валидные_данные()
        {
            Assert.True(ДатаВалидна(DateTime.Now));
            Assert.False(ДатаНЕвалидна(DateTime.Now));
        }

        public DateTime? date_time { get; set; }
    }
}