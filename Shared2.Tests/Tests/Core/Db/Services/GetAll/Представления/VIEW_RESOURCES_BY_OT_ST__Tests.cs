using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Helpers;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Services.GetAll.Представления
{
    [TestFixture]
    public class VIEW_RESOURCES_BY_OT_ST__Tests : Init
    {
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            // действие
            TestDelegate testDelegate = () => repository.GetAll().ToList();
            var all = repository.GetAll().ToList	();
            // утверждение
            Assert.DoesNotThrow(testDelegate);
//            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_SqlQuery__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            List<VIEW_RESOURCES_BY_OT_ST>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewResourcesByOtSt
                    .SqlQuery($"select * from {ИмяТаблицы.ViewResourcesByOtSt} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
//            Assert.IsNotEmpty(all);
        }

        [Test]
        public void Проверка_наличия_таблицы_в_бд()
        {
            Assert.True
            (_sysrlRepository.Найти(r => 
                    r.S13.Trim(' ') == ИмяТаблицы.ViewResourcesByOtSt)
                .S13.Trim(' ') == ИмяТаблицы.ViewResourcesByOtSt);
        }

        [Test]
        public void Проверка_целостности_полей_таблицы_в_бд()
        {
            var idTable = _sysrlRepository.Найти(r => 
                r.S13.Trim(' ') == ИмяТаблицы.ViewResourcesByOtSt).S11;
            
            Assert.True(idTable > 0);

            IEnumerable<string> поляВоПрограмме = new string[]{
                ИмяКолонки.ID_OBJECT,
                ИмяКолонки.ID_RESOURCE,
                ИмяКолонки.NAME,
                ИмяКолонки.ID_OBJECT_TYPE,
                ИмяКолонки.ID_SERVICE_TYPE,
                ИмяКолонки.ID_USER_RESPONSIBLE,
                ИмяКолонки.ID_USER_OWNER,
                ИмяКолонки.LOGIN_RESPONSIBLE,
                ИмяКолонки.LOGIN_OWNER,
                ИмяКолонки.RQ1_ID,
                ИмяКолонки.RQ1_PARENT,
                ИмяКолонки.CREATE_DATE_1,
                ИмяКолонки.CREATE_DATE_2,
                ИмяКолонки.CREATE_REQUEST_STATE,
                ИмяКолонки.CREATE_REQUEST_STATE_NAME,
                ИмяКолонки.CREATE_REQUEST_STATE_CODE,
                ИмяКолонки.RQ2_ID,
                ИмяКолонки.RQ2_PARENT,
                ИмяКолонки.END_DATE_1,
                ИмяКолонки.END_DATE_2,
                ИмяКолонки.END_REQUEST_STATE,
                ИмяКолонки.END_REQUEST_STATE_NAME,
                ИмяКолонки.END_REQUEST_STATE_CODE,
            };
            
            
            var поляВоТаблицеБазы = _attriRepository?.GetMany(r => r.S21 == idTable).ToList();

            foreach (var a in поляВоТаблицеБазы)
                Assert.True
                (поляВоПрограмме.Contains(a.S23.Trim(' ')),                     
                    $"поле в таблице бд: {a.S23}\n" +
                             $" не содержится в списке полей программы:\n" +
                             $" {поляВоПрограмме.Print("\n")}");

            var названиеПолейВоТаблицеБд = поляВоТаблицеБазы.Select(r => r.S23.Trim()).ToList();
            
            foreach (var полеВоПрограмме in поляВоПрограмме)
                Assert.True
                (названиеПолейВоТаблицеБд.Contains(полеВоПрограмме), 
                    $"поле в программе: {полеВоПрограмме}\n" +
                             $" не содержится в списке полей таблицы бд:\n" +
                             $" {названиеПолейВоТаблицеБд.Print("\n")}");    

            var колвоПолейВоПрограмме = поляВоПрограмме.ToList().Count;
            var колвоПолейВоТаблице= поляВоТаблицеБазы.Count;
            
            Assert.True
            (колвоПолейВоПрограмме == колвоПолейВоТаблице , 
                $"полей в программе: {колвоПолейВоПрограмме}, полей в таблице: {колвоПолейВоТаблице}");
        }

        [Test]
        public void Проверяем_выражение_Expression_OT_ST()
        {
            // подготовка
            IVIEW_RESOURCES_BY_OT_ST_Repository repository = new VIEW_RESOURCES_BY_OT_ST_Repository(DB_FACTORY);
            ILinqHelpers linqHelpers = new LinqHelpers();
            CommonService = new Common_Service(repository, linqHelpers);
            
            // утверждение
            Assert.IsNotNull(CommonService);
            Assert.IsNotNull(repository);
            Assert.IsNotNull(linqHelpers);

            // действие
            {
                var enumerable = (CommonService.ПолучитьРесурсыДляФормыСоУсловием(r => true) 
                                  ?? 
                                  Array.Empty<VIEW_RESOURCES_BY_OT_ST>()).ToList();
                
                Assert.IsNotNull(enumerable);
//                Assert.AreNotEqual(enumerable.Count, 0);
                
                var валидные = enumerable
                        .Where(linqHelpers.ФильтрВалидныеДнф<VIEW_RESOURCES_BY_OT_ST>()).ToList();
                
                Assert.IsNotNull(валидные);
//                Assert.AreNotEqual(валидные.Count, 0);
                
                var существуют = (
                        linqHelpers.СуществуетНаДату(валидные, DateTime.Now) 
                         ?? 
                         Array.Empty<VIEW_RESOURCES_BY_OT_ST>())
                    .ToList();
                
 //               Assert.AreNotEqual(существуют.Count, 0);
            }

            // действие
            {
                var enumerable = CommonService
                    .ПолучитьСуществующиеРесурсыДляФормыСоУсловием(r => true, DateTime.Now)!
                    .ToList();
                
                Assert.IsNotNull(enumerable);
//                Assert.AreNotEqual(enumerable!.ToList().Count, 0);
            }
        }
        
        private static VIEW_RESOURCES_BY_OT_ST_Repository Setup() => new VIEW_RESOURCES_BY_OT_ST_Repository(DB_FACTORY);
    }
}