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
    public class VIEW_REPORT_ALL_RESOURCES__Tests : Init
    {
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
            List<VIEW_REPORT_ALL_RESOURCES>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewReportAllResources
                    .SqlQuery($"select * from {ИмяТаблицы.ViewReportAllResources} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
            // Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void Проверка_наличия_таблицы_в_бд()
        {
            Assert.True
            (_sysrlRepository.Exists
            (r =>
                r.S13.Trim(' ') == ИмяТаблицы.ViewReportAllResources));
        }

        [Test]
        public void Проверка_целостности_полей_таблицы_в_бд()
        {
            var idTable = _sysrlRepository.Найти(r => 
                r.S13.Trim(' ') == ИмяТаблицы.ViewReportAllResources).S11;
            
            Assert.True(idTable > 0);

            IEnumerable<string> поляВоПрограмме = new string[]{
                "ID",               
                ИмяКолонки.ID_RESOURCE,
                
                "OBJECT_TYPE_NAME",
                // "ORG_FNAME",
                "ID_REQUEST_TYPE_CODE_1",
                "ID_REQUEST_TYPE_CODE_2",
                "RESOURCE_NAME",                                                     
                "SERVICE_TYPE_NAME",                                                 
                "SERVICE_NAME",                                                      
                "FRAG_NAME",                                                         
                "PATH",                                                              
                "DESCRIPTION",                                                       
                "SECRET_TYPE_NAME",                                                  
                
                "ID_USER_OWNER",
                // "LOGIN_OWNER",
                "OWNER",            
                "OWNER_SHORT_NAME",
                "OWNER_ORG_FNAME",
                "OWNER_JOB_NAME",
                
                "ID_USER_RESPONSIBLE",
                // "LOGIN_RESPONSIBLE",
                "RESPONSIBLE",        
                "RESPONSIBLE_SHORT_NAME",
                "RESPONSIBLE_ORG_FNAME",
                "RESPONSIBLE_JOB_NAME",
                
                "ID_REQUEST_1",
                ИмяКолонки.ID_REQUEST_1_PARENT,
                "CREATE_DATE_1",                                                     
                "CREATE_DATE_2",                                                     
                "CREATE_REQUEST_STATE",
                ИмяКолонки.CREATE_REQUEST_STATE_NAME,
                
                "ID_REQUEST_2",
                ИмяКолонки.ID_REQUEST_2_PARENT,
                "END_DATE_1",                                                        
                "END_DATE_2",                                                        
                "END_REQUEST_STATE",
                ИмяКолонки.END_REQUEST_STATE_NAME,
                "REG_NUM",                                                           
            };
            
            
            var поляВоТаблицеБазы = _attriRepository.GetMany(r => r.S21 == idTable).ToList();

            foreach (var a in поляВоТаблицеБазы)
                Assert.True
                (поляВоПрограмме.Contains(a.S23.Trim(' ')),                     
                    $"поле в таблице {ИмяТаблицы.ViewReportAllResources} бд: {a.S23}\n" +
                             $" не содержится в списке полей программы:\n" +
                             $" {поляВоПрограмме.Print("\n")}");

            var названиеПолейВоТаблицеБд = поляВоТаблицеБазы.Select(r => r.S23.Trim()).ToList();
            
            foreach (var полеВоПрограмме in поляВоПрограмме)
                Assert.True
                (названиеПолейВоТаблицеБд.Contains(полеВоПрограмме), 
                    $"поле в программе: {полеВоПрограмме}\n" +
                             $" не содержится в списке полей таблицы {ИмяТаблицы.ViewReportAllResources} бд:\n" +
                             $" {названиеПолейВоТаблицеБд.Print("\n")}");    

            var колвоПолейВоПрограмме = поляВоПрограмме.ToList().Count;
            var колвоПолейВоТаблице= поляВоТаблицеБазы.Count;
            
            Assert.True
            (колвоПолейВоПрограмме == колвоПолейВоТаблице , 
                $"полей в программе: {колвоПолейВоПрограмме}, полей в таблице: {колвоПолейВоТаблице}");
        }

        private static VIEW_REPORT_ALL_RESOURCES_Repository Setup() => new VIEW_REPORT_ALL_RESOURCES_Repository(DB_FACTORY);
    }
}