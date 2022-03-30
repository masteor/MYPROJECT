using System;
using System.Collections.Generic;
using Autofac;
using AutoFixture;
using DBPSA.Shared.Db.Entities.Таблицы;
using DBPSA.Shared.Db.Services;
using DBPSA.Shared.Models;
using DBPSA.Shared2.Tests.Tests.Core.Db;
using DBPSA.Shared2.Tests.Tests.Core.Extensions;
using DBPSA.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Models.Создать__Пользователя__Тесты
{
    [TestFixture]
    public partial class Создать__Пользователя__Тесты : Init
    {
        [Test]
        public void Проверяем_конструктор__Входные_данные_НЕ_нулл__модель_не_валидна()
        {
            ICommonService сервис = new Common_Service();

            EMPLOYEE[] валидныеПользователиСервиса =
            {
                new EMPLOYEE{ id = 1 }, 
                new EMPLOYEE{ id = _ID },
            };

            {
                var валиднаяМодель = ГенераторМоделей
                    .ПолучитьВалиднуюМодель<ДанныеИзФормы_СозданияПользователя_модель>();

                валиднаяМодель.email += "@sils.local";

                foreach (var пользователь in валидныеПользователиСервиса)
                {
                    foreach (var измененнаяМодель in Рефлектор.ПолучитьМоделиСИзмененнымСвойством(валиднаяМодель))
                    {
                        Assert.True(измененнаяМодель.НеВалидна());
                        
                        var создатьПользователя = new Создать_Пользователя(сервис, пользователь, измененнаяМодель);

                        TestDelegate testDelegate = () =>
                        {
                            создатьПользователя = new Создать_Пользователя(сервис, пользователь, измененнаяМодель);
                        };

                        var exception = создатьПользователя?.Exception;

                        Assert.IsNotNull(создатьПользователя);

                        // должен возвращать исключение
                        Assert.IsNotNull(exception);

                        StringHelper.Print(создатьПользователя);

                        // не должен бросать исключение                            
                        Assert.DoesNotThrow(testDelegate);

                        if (exception!.Message.Contains("Ссылка на объект не указывает на экземпляр объекта"))
                        {
                            PrintTestContext(измененнаяМодель);
                            Assert.AreEqual(exception?.Message, "");
                        }

                        Assert.True(exception?.Message.Contains("Модель не валидна"));

                        // есть исключение - модель = нулл                
                        Assert.IsNull(создатьПользователя?.ПолучитьМодель());

                        // должен возвращать только ArgumentException
                        Assert.AreEqual(создатьПользователя?.Exception?.GetType(), new ArgumentException().GetType());

                        // результат в любом случае должен быть 
                        Assert.IsNotNull(создатьПользователя?.ПолучитьРезультат());

                        // в любом случае возвращает JsonМодель
                        Assert.IsNotNull(создатьПользователя?.ПолучитьJsonМодель());
                    }
                }
            }
        }

        
        [Test]
        public void Создаем_Пользователя_на_валидных_данных()
        {
            using var scope = _container?.BeginLifetimeScope() ?? throw new NullReferenceException();
            var commonService = scope.Resolve<ICommonService>() ?? throw new NullReferenceException();

            EMPLOYEE пользователь = new EMPLOYEE { id=_ID };
            var fixture = new Fixture();
            
            var модель = new ДанныеИзФормы_СозданияПользователя_модель
            {
                family = fixture.Create<string>(),
                name = fixture.Create<string>(),
                patronymic = fixture.Create<string>(),
                date_time = DateTime.Now,
                login_name = ГенераторМоделей.ПолучитьВалидныйЛогин(),
                email = ГенераторМоделей.ПолучитьВалидныйЕмайл(),
                id_domen = 1,
                tnum = 12345,
                id_job = 11,
                id_form_perm = 3,
                job_begin_date = fixture.Create<DateTime>(),
                id_fio = null,
                id_login = null,
                id_user = null
            };

            var b = модель.Валидна();
            if (!b) PrintTestContext(модель.ПолучитьРезультатыВалидации());
            
            Assert.True(модель.Валидна());
            TestContext.Out.WriteLine($"Исключение модели: {StringHelper.Print(модель.получитьИсключение()?.Message)}");
            
            PrintTestContext(модель);

            // не должен бросать исключение                            
            Assert.DoesNotThrow(() => new Создать_Пользователя(commonService, пользователь, модель));
            
            Создать_Пользователя? unused = new Создать_Пользователя(commonService, пользователь, модель);
            
            // конструктор должен вернуть объект 
            Assert.IsNotNull(unused);
            
            // не должен возвращать исключение
            Assert.IsNull(unused?.Exception);

            // модель не нулл                
            Assert.IsNotNull(unused?.ПолучитьМодель());
                
            // результат в любом случае должен быть 
            Assert.IsNotNull(unused?.ПолучитьРезультат());

            // в любом случае возвращает JsonМодель
            Assert.IsNotNull(unused?.ПолучитьJsonМодель());
            
            var заявка = unused?.ПолучитьЗаявку();
            var фио = unused?.ПолучитьФИО();
            
            Console.WriteLine($@"code = {StringHelper.Print(unused.ПолучитьРезультат()?.code)}");
            Console.WriteLine(unused.ПолучитьРезультат()?.msg);
            Console.WriteLine($@"ид заявки: {StringHelper.Print(заявка?.id)}");
            Console.WriteLine($@"ид фио: {StringHelper.Print(фио?.id)}");
            
            Assert.AreEqual(unused.ПолучитьРезультат()?.code, 200);
            Assert.IsTrue(unused.ПолучитьРезультат()?.msg.Contains("успешно создан"));
            
            Assert.GreaterOrEqual(фио?.id, 1);
            Assert.GreaterOrEqual(заявка?.id, 1);
        }
    }
}