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
    public class VIEW_ARM_ROOM_USER__Tests : Init
    {
        private const string ИМЯ_ТАБЛИЦЫ = ИмяТаблицы.ViewArmRoomUser;

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
            List<VIEW_ARM_ROOM_USER>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewArmRoomUsers
                    .SqlQuery($"select * from {ИмяТаблицы.ViewArmRoomUser} ")
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
                ИмяКолонки.ID,
                ИмяКолонки.REG_NUM_ARM,
                ИмяКолонки.ARM_ID_NEW,
                ИмяКолонки.REG_NUM_LOGBOOK,
                ИмяКолонки.ROOM_NUM,
                ИмяКолонки.BUILDING_NAME,
                ИмяКолонки.PROM_AREA_NAME,
                ИмяКолонки.ARM_USER_ID_USER,
                ИмяКолонки.USER_ROOM_ID_USER,
                ИмяКолонки.ARM_ID_REQUEST_1,
                ИмяКолонки.CREATE_DATE_1,
                ИмяКолонки.CREATE_DATE_2,
                ИмяКолонки.CREATE_REQUEST_STATE,
                ИмяКолонки.ARM_ID_REQUEST_2,
                ИмяКолонки.END_DATE_1,
                ИмяКолонки.END_DATE_2,
                ИмяКолонки.END_REQUEST_STATE,
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

        private static VIEW_ARM_ROOM_USER_Repository Setup() => new VIEW_ARM_ROOM_USER_Repository(DB_FACTORY);
    }
}