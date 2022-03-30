using System.Collections.Generic;
using System.Linq;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;
using DBPSA.Shared.Db.Repositories;
using DBPSA.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Db.Services.GetAll.Представления
{
    [TestFixture]
    public class VIEW_EMPLOYEE_PRD__Tests : Init
    {
        private const string ИМЯ_ТАБЛИЦЫ = ИмяТаблицы.ViewEmployeePrd;

        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            // действие
            TestDelegate testDelegate = () => repository.GetAll().ToList();
            var all = repository.GetAll().ToList();
            // утверждение
            Assert.DoesNotThrow(testDelegate);
            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_SqlQuery__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            List<VIEW_EMPLOYEE_PRD>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewEmployeePrds
                    .SqlQuery($"select * from {ИмяТаблицы.ViewEmployeePrd} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
            Assert.IsNotEmpty(all);
        }

        [Test]
        public void Проверка_наличия_таблицы_в_бд()
        {
            Assert.True
            (_sysrlRepository.Найти(r => 
                    r.S13.Trim(' ') == ИМЯ_ТАБЛИЦЫ)
                .S13.Trim(' ') == ИМЯ_ТАБЛИЦЫ);
        }

        [Test]
        public void Проверка_целостности_полей_таблицы_в_бд()
        {
            var idTable = _sysrlRepository.Найти(r => 
                r.S13.Trim(' ') == ИМЯ_ТАБЛИЦЫ).S11;
            
            Assert.True(idTable > 0);

            IEnumerable<string> поляВоПрограмме = new string[]{
                ИмяКолонки.ID_EMPLOYEE,
                ИмяКолонки.TNUM,
                ИмяКолонки.EMPLOYEE_FIO_FULL,
                ИмяКолонки.LOGIN,
                ИмяКолонки.FORM_PERM	,
                ИмяКолонки.IS_ACTIVE,
                ИмяКолонки.IS_ACTIVE_DESCR,
                ИмяКолонки.JOB_NAME,
                ИмяКолонки.WPHONE,
                ИмяКолонки.HPHONE,
                ИмяКолонки.BUILD,
                ИмяКолонки.PROM_AREA,
                ИмяКолонки.ROOM,
                ИмяКолонки.DEP_DESCR,
                ИмяКолонки.DIV_DESCR,
                ИмяКолонки.LAB_DESCR,
                ИмяКолонки.DEP_BOSS_FIO_FULL,
                ИмяКолонки.DIV_BOSS_FIO_FULL,
                ИмяКолонки.LAB_BOSS_FIO_FULL,
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

        private static VIEW_EMPLOYEE_PRD__Repository Setup() => new VIEW_EMPLOYEE_PRD__Repository(DB_FACTORY);
    }
}