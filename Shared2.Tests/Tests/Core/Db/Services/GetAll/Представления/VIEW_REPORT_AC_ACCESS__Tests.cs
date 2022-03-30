using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Services.GetAll.Представления
{
    [TestFixture]
    public class VIEW_REPORT_AC_ACCESS__Tests : Init
    {
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            // действие
            TestDelegate testDelegate = () => repository.GetAll().ToList	();
            var all = repository.GetAll().ToList	();
            // утверждение
            Assert.DoesNotThrow(testDelegate);
            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_SqlQuery__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            List<VIEW_REPORT_AC_ACCESS>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewReportAcAccess
                    .SqlQuery($"select * from {ИмяТаблицы.ViewReportAcAccessPrd} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_GetMany_true()
        {
            // подготовка
            var repository = Setup();
            // действие
            var all= repository.GetMany(access => true);
            // утверждение
            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_GetMany_false()
        {
            // подготовка
            var repository = Setup();
            // действие
            var all= repository.GetMany(access => false);
            // утверждение
            Assert.IsEmpty(all);
        }
        
        [Test]
        public void TEST_GetMany_OR_data_is_null()
        {
            // подготовка
            var repository = Setup();
            
            // действие
            
            // если дата нулевая всегда должен возвращать все данные
            DateTime? data = null;
            var count = repository.GetMany(r => true).Count();
            var all1= repository.GetMany(r => false || data == null);
            var all2= repository.GetMany(r => true || data == null);
            
            // утверждение
            Assert.True(all1.Count() == count);
            Assert.True(all2.Count() == count);
        }

        [Test]
        public void Проверка_наличия_таблицы_в_бд()
        {
            Assert.True
            (_sysrlRepository.Найти(r => 
                    r.S13.Trim(' ') == ИмяТаблицы.ViewReportAcAccess)
                .S13.Trim(' ') == ИмяТаблицы.ViewReportAcAccess);
        }
        
        [Test]
        public void Проверка_целостности_полей_таблицы_в_бд()
        {
            var idTable = _sysrlRepository.Найти(r => 
                r.S13.Trim(' ') == ИмяТаблицы.ViewReportAcAccess).S11;
            
            Assert.True(idTable > 0);

            IEnumerable<string> поляВоПрограмме = new string[]{
                "ID_AC_ACCESS", 
                "TNUM",
                "FAMILY",
                "NAME",
                "PATRONYMIC",
                "ORG_FNAME",
                "CREATE_DATE_1",
                "CREATE_DATE_2",
                "CREATE_REQUEST_STATE",
                "END_DATE_1",
                "END_DATE_2",
                "END_REQUEST_STATE",
                "REG_NUM"
            };
            
            
            var поляВоТаблицеБазы = _attriRepository.GetMany(r => r.S21 == idTable).ToList();

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

        private static VIEW_REPORT_AC_ACCESS_Repository Setup() => new VIEW_REPORT_AC_ACCESS_Repository(DB_FACTORY);
    }
}