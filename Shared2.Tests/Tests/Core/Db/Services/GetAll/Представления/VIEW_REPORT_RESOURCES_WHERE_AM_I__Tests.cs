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
    public class VIEW_REPORT_RESOURCES_WHERE_AM_I__Tests : Init
    {
        private const string ИМЯ_ТАБЛИЦЫ = ИмяТаблицы.VIEW_REPORT_RESOURCES_WHERE_AM_I;

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
//            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_SqlQuery__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            List<VIEW_REPORT_RESOURCES_WHERE_AM_I>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewReportResourcesWhereAmI
                    .SqlQuery($"select * from {ИмяТаблицы.VIEW_REPORT_RESOURCES_WHERE_AM_I} ")
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
                ИмяКолонки.ID_RESOURCE,
                ИмяКолонки.RESOURCE_NAME,
                ИмяКолонки.OBJECT_TYPE_NAME,
                ИмяКолонки.SERVICE_TYPE_NAME,
                ИмяКолонки.SERVICE_NAME,
                ИмяКолонки.FRAG_NAME,
                ИмяКолонки.PATH,
                ИмяКолонки.DESCRIPTION,
                ИмяКолонки.SECRET_TYPE_NAME,
                ИмяКолонки.ID_USER_OWNER,
                // ИмяКолонки.LOGIN_OWNER,
                ИмяКолонки.FIO_OWNER,
                ИмяКолонки.ID_USER_RESPONSIBLE,
                // ИмяКолонки.LOGIN_RESPONSIBLE,
                ИмяКолонки.FIO_RESPONSIBLE,
                ИмяКолонки.ID_REQUEST_1,
                ИмяКолонки.PARENT_1,
                ИмяКолонки.ID_REQUEST_TYPE_CODE_1,
                ИмяКолонки.CREATE_DATE_1,
                ИмяКолонки.CREATE_DATE_2,
                ИмяКолонки.CREATE_REQUEST_STATE,
                ИмяКолонки.CREATE_REQUEST_STATE_NAME,
                ИмяКолонки.ID_REQUEST_2,
                ИмяКолонки.PARENT_2,
                ИмяКолонки.ID_REQUEST_TYPE_CODE_2,
                ИмяКолонки.END_DATE_1,
                ИмяКолонки.END_DATE_2,
                ИмяКолонки.END_REQUEST_STATE,
                ИмяКолонки.END_REQUEST_STATE_NAME,
                ИмяКолонки.REG_NUM,
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

        private static VIEW_REPORT_RESOURCES_WHERE_AM_I_Repository Setup() => new VIEW_REPORT_RESOURCES_WHERE_AM_I_Repository(DB_FACTORY);
    }
}