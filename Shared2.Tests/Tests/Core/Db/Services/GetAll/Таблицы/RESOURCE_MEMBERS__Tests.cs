using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
// using QWERTY.Shared.Tests.Extentions;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Services.GetAll.Таблицы
{
    [TestFixture]
    public class RESOURCE_MEMBERS__Tests : Init
    {
        private const string ИМЯ_ТАБЛИЦЫ = ИмяТаблицы.RESOURCE_MEMBERS;

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
        public void Проверка_наличия_таблицы_в_бд()
        {
            Assert.True
            (_sysrlRepository.Найти(r => 
                    r.S13.Trim(' ') == ИМЯ_ТАБЛИЦЫ)
                .S13.Trim(' ') == ИМЯ_ТАБЛИЦЫ);
        }
        
        [Test]
        public void TEST_SqlQuery__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            List<RESOURCE_MEMBER>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .RESOURCE_MEMBERS
                    .SqlQuery($"select * from {ИМЯ_ТАБЛИЦЫ} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
            Assert.IsNotEmpty(all);
        }

        /*[Test]
        public void Проверка_целостности_полей_таблицы_в_бд()
        {
            var idTable = _sysrlRepository.Найти(r => 
                r.S13.Trim(' ') == ИМЯ_ТАБЛИЦЫ).S11;
            
            Assert.True(idTable > 0);

            IEnumerable<string> поляВоПрограмме = new string[]{
                ИмяКолонки.ID,
                ИмяКолонки.ID_RESOURCE,
                ИмяКолонки.ID_LOGIN,
                ИмяКолонки.ID_ORG,
                ИмяКолонки.ID_REQUEST_1,
                ИмяКолонки.ID_REQUEST_2,
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
        }*/

        private static RESOURCE_MEMBERS_Repository Setup() => new RESOURCE_MEMBERS_Repository(DB_FACTORY);
    }
}