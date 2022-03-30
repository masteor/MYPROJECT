using System;
using System.Linq;
using System.Reflection;
using DBPSA.Shared.Db.Entities.Таблицы;
using DBPSA.Shared.Enums;
using DBPSA.Shared.Models;
using DBPSA.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Models.ДанныеИзФормы__Тесты
{
    [TestFixture]
    public class ДанныеИзФормы_СозданияФИО_модель__Тесты : Init
    {
        ДанныеИзФормы_СозданияФИО_модель ПолучитьВалиднуюМодель()
        {
            var данныеИзФормыСозданияФиоМодель =
                ГенераторМоделей.ПолучитьВалиднуюМодель<ДанныеИзФормы_СозданияФИО_модель>();
            return данныеИзФормыСозданияФиоМодель;
        }
        
        [Test]
        public void TestTest()
        {
            foreach (var измененнаяМодель in Рефлектор.ПолучитьМоделиСИзмененнымСвойством(ПолучитьВалиднуюМодель()))
            {
                var неВалидна = измененнаяМодель.НеВалидна();
                if (!неВалидна) PrintTestContext(измененнаяМодель);
                Assert.True(неВалидна);
            }
        }
        
        
        [Test]
        public void ДанныеИзФормы_СозданияФИО_модель__Валидные_данные()
        {
            {
                IДанныеИзФормы_СозданияФИО_модель модель = new ДанныеИзФормы_СозданияФИО_модель()
                {
                    family = "вукаепнрогьлшбщд",
                    name = "xdrectfvbgh",
                    patronymic = "xdrcfvgbh",
                    date_time = DateTime.Now,
                };

                var b = модель.Валидна();
                if (!b) PrintTestContext(модель.ПолучитьРезультатыВалидации());
                
                Assert.True(модель.Валидна());    
            }

            {
                var модель = ПолучитьВалиднуюМодель();
 
                Assert.IsNotNull(модель);
                
                PrintTestContext(модель);
                Assert.True(модель.Валидна());
                
                Assert.IsNull(модель.получитьИсключение());
                PrintTestContext(модель.получитьИсключение()?.Message);
            }
        }

    }
}