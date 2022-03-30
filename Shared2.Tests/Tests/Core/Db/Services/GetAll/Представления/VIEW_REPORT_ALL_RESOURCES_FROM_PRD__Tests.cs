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
    public class VIEW_REPORT_ALL_RESOURCES_FROM_PRD__Tests : Init
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
        }
        
        [Test]
        public void TEST_SqlQuery__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            List<VIEW_REPORT_ALL_RESOURCES_FROM_PRD>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewReportAllResourcesFromPrd
                    .SqlQuery($"select * from {ИмяТаблицы.ViewReportAllResourcesFromPrd} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void Проверка_наличия_таблицы_в_бд()
        {
            Assert.True
            (_sysrlRepository.Exists
            (r =>
                r.S13.Trim(' ') == ИмяТаблицы.ViewReportAllResourcesFromPrd));
        }

        [Test]
        public void Проверка_целостности_полей_таблицы_в_бд()
        {
            var idTable = _sysrlRepository.Найти(r => 
                r.S13.Trim(' ') == ИмяТаблицы.ViewReportAllResourcesFromPrd).S11;
            
            Assert.True(idTable > 0);

            IEnumerable<string> поляВоПрограмме = new string[]{
                "ID",                                                                
                "RESOURCE_NAME",                                                     
                "SERVICE_TYPE_NAME",                                                 
                "SERVICE_NAME",                                                      
                "FRAG_NAME",                                                         
                "PATH",                                                              
                "DESCRIPTION",                                                       
                "SECRET_TYPE_NAME",                                                  
                "OWNER",                                                             
                "RESPONSIBLE",                                                       
                "CREATE_DATE_1",                                                     
                "CREATE_DATE_2",                                                     
                "CREATE_REQUEST_STATE",                                              
                "END_DATE_1",                                                        
                "END_DATE_2",                                                        
                "END_REQUEST_STATE",                                                 
                "REG_NUM",                                                           
            };
            
            
            var поляВоТаблицеБазы = _attriRepository.GetMany(r => r.S21 == idTable).ToList();

            foreach (var a in поляВоТаблицеБазы)
                Assert.True
                (поляВоПрограмме.Contains(a.S23.Trim(' ')),                     
                    $"поле в таблице {ИмяТаблицы.ViewReportAllResourcesFromPrd} бд: {a.S23}\n" +
                             $" не содержится в списке полей программы:\n" +
                             $" {поляВоПрограмме.Print("\n")}");

            var названиеПолейВоТаблицеБд = поляВоТаблицеБазы.Select(r => r.S23.Trim()).ToList();
            
            foreach (var полеВоПрограмме in поляВоПрограмме)
                Assert.True
                (названиеПолейВоТаблицеБд.Contains(полеВоПрограмме), 
                    $"поле в программе: {полеВоПрограмме}\n" +
                             $" не содержится в списке полей таблицы {ИмяТаблицы.ViewReportAllResourcesFromPrd} бд:\n" +
                             $" {названиеПолейВоТаблицеБд.Print("\n")}");    

            var колвоПолейВоПрограмме = поляВоПрограмме.ToList().Count;
            var колвоПолейВоТаблице= поляВоТаблицеБазы.Count;
            
            Assert.True
            (колвоПолейВоПрограмме == колвоПолейВоТаблице , 
                $"полей в программе: {колвоПолейВоПрограмме}, полей в таблице: {колвоПолейВоТаблице}");
        }

        private static VIEW_REPORT_ALL_RESOURCES_FROM_PRD_Repository Setup() => new VIEW_REPORT_ALL_RESOURCES_FROM_PRD_Repository(DB_FACTORY);
    }
}