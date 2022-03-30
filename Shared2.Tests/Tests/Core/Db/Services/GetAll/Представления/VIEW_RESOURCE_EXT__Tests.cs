﻿using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Repositories;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Db.Services.GetAll.Представления
{
    [TestFixture]
    public class VIEW_RESOURCE_EXT__Tests : Init
    {
        [Test]
        public void TEST_GetAll__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            // действие
            TestDelegate testDelegate = () =>
            {
                var viewResourceExts = repository.GetAll().ToList();
            };
            // утверждение
            Assert.DoesNotThrow(testDelegate);
            
            var all = repository.GetAll().ToList();
//            Assert.IsNotEmpty(all);
        }
        
        [Test]
        public void TEST_SqlQuery__DoesNotThrow()
        {
            // подготовка
            var repository = Setup();
            List<VIEW_RESOURCE_EXT>? all = null;
            
            // действие
            void TestDelegate() 
                => all = repository
                    .GetContext()
                    .ViewResourceExt
                    .SqlQuery($"select * from {ИмяТаблицы.ViewResourceExt} ")
                    .ToList();

            // утверждение
            Assert.DoesNotThrow(TestDelegate);
//            Assert.IsNotEmpty(all);
        }

        [Test]
        public void Проверка_наличия_таблицы_в_бд()
        {
            Assert.True
            (_sysrlRepository?.Найти(r => 
                    r.S13.Trim(' ') == ИмяТаблицы.ViewResourceExt)
                .S13.Trim(' ') == ИмяТаблицы.ViewResourceExt);
        }

        [Test]
        public void Проверка_целостности_полей_таблицы_в_бд()
        {
            var idTable = _sysrlRepository?.Найти(r => 
                r.S13.Trim(' ') == ИмяТаблицы.ViewResourceExt).S11;
            
            Assert.True(idTable > 0);

            IEnumerable<string> поляВоПрограмме = new string[]{
                ИмяКолонки.ID_RESOURCE,
                ИмяКолонки.RESOURCE_ID_OBJECT,                                                
                ИмяКолонки.ID_OBJECT,                                                         
                ИмяКолонки.OBJECT_NAME,                                                       
                ИмяКолонки.ID_OBJECT_TYPE,                                                    
                ИмяКолонки.OBJECT_TYPE_NAME,                                                  
                ИмяКолонки.ID_SERVICE_TYPE,                                                   
                
                ИмяКолонки.CREATE_DATE_1,
                ИмяКолонки.CREATE_DATE_2,
                ИмяКолонки.CREATE_REQUEST_STATE,
                ИмяКолонки.END_DATE_1,
                ИмяКолонки.END_DATE_2,
                ИмяКолонки.END_REQUEST_STATE,
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

        private static VIEW_RESOURCE_EXT_Repository Setup() => new VIEW_RESOURCE_EXT_Repository(DB_FACTORY);
    }
}