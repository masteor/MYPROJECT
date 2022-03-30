using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Services.GetAll.Таблицы
{
    /// <summary>
    /// Сначала проверяем маппинги - правильно ли они созданы, на те ли поля они смотрят
    /// это проверяется через процедуру GetAll - самое главное тут отправка SQL запроса,
    /// а не то, что он вернет
    /// </summary>
    [TestFixture]
    public class DOC_RepositoryTests : Init
    {
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();

            // действие
            TestDelegate testDelegate = () => repository.GetAll().ToList();
            var all = repository
                .GetMany(r => true)
                .ToList	();

            // утверждение
            Assert.DoesNotThrow(testDelegate);
//            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void Проверка_наличия_таблицы_в_бд()
        {
            Assert.True
            (_sysrlRepository?.Найти(r => 
                    r.S13.Trim(' ') == "_DOC")
                .S13.Trim(' ') == "_DOC");
        }
        
        [Test]
        public void Проверка_целостности_полей_таблицы_в_бд()
        {
            var idTable = _sysrlRepository!.Найти(r => 
                r.S13.Trim(' ') == "_DOC").S11;
            
            Assert.True(idTable > 0);

            IEnumerable<string> поляВоПрограмме = new string[]{
                ИмяКолонки.ID,                                                                                                                                                                                                      
                ИмяКолонки.ID_DOC_TYPE,                                                                                                                                                                                             
                ИмяКолонки.CONTENTS,                                                                                                                                                                                                
                ИмяКолонки.DATE_1,                                                                                                                                                                                                  
                ИмяКолонки.STATE,                                                                                                                                                                                                   
                ИмяКолонки.DOC_REG_NUM,                                                                                                                                                                                             
                ИмяКолонки.DOC_REG_DATE,                                                                                                                                                                                            
                ИмяКолонки.ID_PARENT,                                                                                                                                                                                               
                ИмяКолонки.PATH,                                                                                                                                                                                                    
                ИмяКолонки.ID_REQUEST_1,                                                                                                                                                                                            
                ИмяКолонки.ID_REQUEST_2,                                                                                                                                                                                            

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

        private static DOC_Repository Setup() => new DOC_Repository(DB_FACTORY);
    }
}
