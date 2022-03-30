using System;
using AutoFixture;
using DBPSA.Shared.Db.Entities.Таблицы;
using DBPSA.Shared.Models;
using DBPSA.Shared2.Tests.Tests.Core.Db;
using DBPSA.Shared2.Tests.Обслуживание_Тестов;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Models.ДанныеИзФормы__Тесты
{
    [TestFixture]
    public class ДанныеИзФормы_СозданияПользователя_модель__Тесты : Init
    {
        [Test]
        public void TestTest()
        {
            ДанныеИзФормы_СозданияПользователя_модель валиднаяМодель =
                ГенераторМоделей.ПолучитьВалиднуюМодель<ДанныеИзФормы_СозданияПользователя_модель>();
            
            валиднаяМодель.email += "@sils.local";

            foreach (var измененнаяМодель in Рефлектор.ПолучитьМоделиСИзмененнымСвойством(валиднаяМодель))
            {
                Assert.True(измененнаяМодель.НеВалидна());
            }
        }

        [Test]
        public void ДанныеИзФормы_СозданияПользователя_модель__Валидные_данные()
        {
            {
                var модель = new ДанныеИзФормы_СозданияПользователя_модель
                {
                    family = "xsrdcvfgbh",
                    name = "xdrectfvbgh",
                    patronymic = "xdrcfvgbh",
                    date_time = DateTime.Now,
                    login_name = "xrsdcfvgbh",
                    email = "drexyvgbh@sils.local",
                    id_domen = 1,
                    tnum = 1,
                    id_job = 1,
                    id_form_perm = 1,
                    job_begin_date = new DateTime(2000, 1,1),
                    id_fio = 0,
                    id_login = null,
                    id_user = null,
                };
                
                Assert.True(модель.Валидна());
                Assert.True(модель.ВалиднаDataAnnotation());
            }

            {
                IДанныеИзФормы_СозданияПользователя_модель модель =
                    ГенераторМоделей.ПолучитьВалиднуюМодель<ДанныеИзФормы_СозданияПользователя_модель>();

                модель.email = "123456789@sils.local";
 
                Assert.IsNotNull(модель);

                var b = модель.Валидна();
                var результатыВалидации = модель.ПолучитьРезультатыВалидации();

                PrintTestContext(модель);
                if (!b)
                    PrintTestContext(результатыВалидации);
                
                Assert.AreEqual(результатыВалидации.Count, 0);
                Assert.True(b);
                
                
                Assert.IsNull(модель.получитьИсключение());
                PrintTestContext(модель.получитьИсключение()?.Message);
            }
        }
    }
}