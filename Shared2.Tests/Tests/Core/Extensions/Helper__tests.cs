using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using QWERTY.Shared.Extensions.For_Tests;
using QWERTY.Shared.Helpers;
using NUnit.Framework;
using static QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.InitModule;

namespace QWERTY.Shared2.Tests.Tests.Core.Extensions
{
    [TestFixture]    
    public class Tests
    {
        private readonly ILinqHelpers _linqHelpers;
        public Tests()
        {
            _linqHelpers = new LinqHelpers();
        }        
        /// <summary>
        /// НаДату(null, null)
        /// </summary>
        [Test]
        public void Коллекция_нулл_дата_нулл__не_бросает_исключение_возвращает_null()
        {
            // подготовка

            // действие
            // ReSharper disable once ExpressionIsAlwaysNull
            void TestDelegate() => _linqHelpers.СуществуетНаДату<EntityClass>(null, null);
            var objects = _linqHelpers.СуществуетНаДату<EntityClass>(null, null);
            
            // утверждение
            Assert.DoesNotThrow(TestDelegate);
            Assert.IsEmpty(objects);
        }
        

        /// <summary>
        /// НаДату(collection, null)
        /// </summary>
        [Test]
        public void Коллекция_инициализирована_конструктором_элемента_дата_null__не_бросает_исключение_Возвращает_пустую_коллекцию()
        {
            // подготовка
            IEnumerable<EntityClass> entityClasses = new List<EntityClass>{new EntityClass()};
            
            // действие
            // void TestDelegate() => _linqHelpers.НаДату(entityClasses, null);
            var result = _linqHelpers.СуществуетНаДату(entityClasses, null);
            
            // утверждение
            Assert.IsNotEmpty(entityClasses);
            Assert.True(entityClasses.Count() == 1); // себя проверяю, что передал коллекцию
            Assert.True(result != null);
            Assert.AreEqual(0, result.ToList().Count);
            // Assert.DoesNotThrow(TestDelegate);
        }
        
        /// <summary>
        /// НаДату(collection, null)
        /// </summary>
        [Test]
        public void Коллекция_инициализирована_элементом_с_валидным_значением_дата_null__не_бросает_исключение_возвращает_коллекцию()
        {
            // подготовка
            IEnumerable<EntityClass> entityClasses = new List<EntityClass>{new EntityClass
                {
                    create_date_1 = DateTime.Now,
                    create_date_2 = DateTime.Now,
                    create_request_state = 1,
                    end_date_1 = null,
                    end_date_2 = null,
                    end_request_state = null
                }
            };
            
            // действие
            // void TestDelegate() => _linqHelpers.НаДату(entityClasses, null);
            var result = _linqHelpers.СуществуетНаДату(entityClasses, null);
            
            // утверждение
            Assert.IsNotEmpty(entityClasses);
            Assert.True(entityClasses.Count() == 1); // себя проверяю, что передал коллекцию
            Assert.True(result != null && entityClasses.Count() == result.ToList().Count);
            // Assert.DoesNotThrow(TestDelegate);
        }
        
        /// <summary>
        /// helper.НаДату(null, DateTime)
        /// </summary>
        [Test]
        public void Коллекция_нулл_дата_разные_значения__не_бросает_исключение_возвращает_null()
        {
            // подготовка
            DateTime anyDateTime = ПолучитьФикстуру<DateTime>();
            
            // действие
            // ReSharper disable once ExpressionIsAlwaysNull
            TestDelegate tdDateTimeMinValue = () => _linqHelpers.СуществуетНаДату<EntityClass>(null, DateTime.MinValue);
            TestDelegate tdDateTimeMaxValue = () => _linqHelpers.СуществуетНаДату<EntityClass>(null, DateTime.MaxValue);
            TestDelegate tdDateTimeAny = () => _linqHelpers.СуществуетНаДату<EntityClass>(null, anyDateTime);
            
            // утверждение
            Assert.DoesNotThrow(tdDateTimeMaxValue);
            Assert.DoesNotThrow(tdDateTimeMinValue);
            Assert.DoesNotThrow(tdDateTimeAny);
            Assert.IsNull(_linqHelpers.СуществуетНаДату<EntityClass>(null, anyDateTime));
        }

        
        
        /// <summary>
        /// helper.НаДату(collection, DateTime)
        /// </summary>
        public void Коллекция_инициализирована_одним_значением_из_конструктора_дата_разные_значения__не_бросает_исключение_возвращает_не_null()
        {
            // подготовка
            IEnumerable<EntityClass> entityClasses = new[] {new EntityClass()};
            DateTime anyDateTime = ПолучитьФикстуру<DateTime>();
            
            // действие
            // ReSharper disable once ExpressionIsAlwaysNull
            void TdDateTimeMinValue() => _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MinValue);
            var resDateTimeMinValue = (List<EntityClass>) _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MinValue);
            
            TestDelegate tdDateTimeMaxValue = () => _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MaxValue);
            var resDateTimeMaxValue = (List<EntityClass>)_linqHelpers.СуществуетНаДату(entityClasses, DateTime.MaxValue);

            TestDelegate tdDateTimeAny = () => _linqHelpers.СуществуетНаДату(entityClasses, anyDateTime);
            var resDateTimeAny = (List<EntityClass>)_linqHelpers.СуществуетНаДату(entityClasses, anyDateTime);
            
            // утверждение
            Assert.DoesNotThrow(tdDateTimeMaxValue);
            Assert.True(resDateTimeMaxValue.Count == entityClasses.Count());
            
            Assert.DoesNotThrow(TdDateTimeMinValue);
            Assert.True(resDateTimeMinValue.Count == entityClasses.Count());
            
            Assert.DoesNotThrow(tdDateTimeAny);
            Assert.True(resDateTimeAny.Count == entityClasses.Count());
        }

        [Test]
        public void Коллекция_из_одного_элемента_заполнена_нуллевыми_значениями_дата_не_нулл__исключений_нет_возвращает_пустой_список()
        {
            // подготовка
            DateTime anyDateTime = ПолучитьФикстуру<DateTime>();

            IEnumerable<EntityClass> entityClasses = new List<EntityClass>{new EntityClass()};
            
            // действие
            void TdDateTimeMinValue() => _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MinValue);
            var resDateTimeMinValue = entityClasses
                .Where(_linqHelpers.ФильтрСуществуетНаДату<EntityClass>(DateTime.MinValue)).ToList(); 

            void TdDateTimeMaxValue() => _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MaxValue);
            var resDateTimeMaxValue = _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MaxValue);

            void TdDateTimeAny() => _linqHelpers.СуществуетНаДату(entityClasses, anyDateTime);
            var resDateTimeAny = _linqHelpers.СуществуетНаДату(entityClasses, anyDateTime);
            
            // утверждение
            Assert.DoesNotThrow(TdDateTimeMinValue);
            Assert.True(resDateTimeMinValue.Count == 0);
            
            Assert.DoesNotThrow(TdDateTimeMaxValue);
            Assert.True(resDateTimeMaxValue.ToList().Count == 0);
            
            Assert.DoesNotThrow(TdDateTimeAny);
            Assert.True(resDateTimeAny.ToList().Count == 0);
        }
        
        
        [Test]
        public void Одна_заявка_создана_успешно_но_еще_не_закрыта_дата_имеет_разные_значения__исключений_нет_возвращает_список_с_этой_заявкой()
        {
            // подготовка
            IEnumerable<EntityClass> entityClasses = new List<EntityClass>
            {
                new EntityClass
                {
                    create_request_state = 4,
                    create_date_1 = new DateTime(2002, 10, 14),
                    create_date_2 = new DateTime(2002, 10, 15),
                    end_request_state = null,
                    end_date_1 = null,
                    end_date_2 = null 
                }
            };
            
            
            {
                // DateTime.MinValue < Rq1Date1 
                // действие
                void TdDateTimeMinValue() => _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MinValue);
                var resDateTimeMinValue = _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MinValue);
                // утверждение
                Assert.DoesNotThrow(TdDateTimeMinValue);
                Assert.True(resDateTimeMinValue.ToList().Count == 0);
            } {
                // Rq1Date1 < Rq1Date2 < DateTime.MaxValue
                // действие
                void TdDateTimeMaxValue() => _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MaxValue);
                var resDateTimeMaxValue = _linqHelpers.СуществуетНаДату(entityClasses, DateTime.MaxValue);
                // утверждение
                Assert.DoesNotThrow(TdDateTimeMaxValue);
                Assert.True(resDateTimeMaxValue.ToList().Count == 1);    
            } {
                //  Rq1Date2 < (Rq1Date2 = fixDate)
                // действие
                var fixDate = new DateTime(2002, 10, 15);
                void TdDateTimeFix() => _linqHelpers.СуществуетНаДату(entityClasses, fixDate);
                var resDateTimeFix = _linqHelpers.СуществуетНаДату(entityClasses, fixDate);
                // утверждение
                Assert.DoesNotThrow(TdDateTimeFix);
                Assert.True(resDateTimeFix.ToList().Count == 1);    
            } {
                // Rq1Date1 < Rq1Date2 < fixDate
                // действие
                var fixDate = new DateTime(2002, 10, 15, 1, 1, 1);
                void TdDateTimeFix() => _linqHelpers.СуществуетНаДату(entityClasses, fixDate);
                var resDateTimeFix = _linqHelpers.СуществуетНаДату(entityClasses, fixDate);
                // утверждение
                Assert.DoesNotThrow(TdDateTimeFix);
                Assert.True(resDateTimeFix.ToList().Count == 1);
            } {
                // Rq1Date1 < fixDate < Rq1Date2
                // действие
                var fixDate = new DateTime(2002, 10, 14, 1, 1, 1);
                void TdDateTimeFix() => _linqHelpers.СуществуетНаДату(entityClasses, fixDate);
                var resDateTimeFix = _linqHelpers.СуществуетНаДату(entityClasses, fixDate);
                // утверждение
                Assert.DoesNotThrow(TdDateTimeFix);
                Assert.True(resDateTimeFix.ToList().Count == 0);
            }
        }
    }
}