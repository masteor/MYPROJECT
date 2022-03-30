using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
// using QWERTY.Shared.Tests.Extentions;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Services.GetAll.Представления
{
    [TestFixture]
    public class VIEW_EMPLOYEE_EXT__Tests : Init
    {
        private const string ИМЯ_ТАБЛИЦЫ = ИмяТаблицы.ViewEmployeeExt;

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
            List<VIEW_EMPLOYEE_EXT>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewEmployeeExts
                    .SqlQuery($"select * from {ИмяТаблицы.ViewEmployeeExt} ")
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
                ИмяКолонки.ID_USER,
                ИмяКолонки.TNUM,
                ИмяКолонки.DATE_1,
                ИмяКолонки.DATE_2,
                ИмяКолонки.ID_NEW,
                ИмяКолонки.ID_REQUEST_1,
                ИмяКолонки.ID_REQUEST_2,
                ИмяКолонки.JOB_NAME,
                ИмяКолонки.FP_NAME,
                ИмяКолонки.FP_DESCRIPTION,
                ИмяКолонки.LOGIN_NAME,
                ИмяКолонки.ID_DOMEN,
                ИмяКолонки.ORG_FNAME,
                ИмяКолонки.NAME_1,
                ИмяКолонки.NAME_2,
                ИмяКолонки.NAME_3,
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

        private static VIEW_EMPLOYEE_EXT_Repository Setup() => new VIEW_EMPLOYEE_EXT_Repository(DB_FACTORY);
    }
}