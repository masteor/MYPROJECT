using System;
using System.Collections.Generic;
using Autofac;
using AutoFixture;
using DBPSA.Shared.Db.Entities.Таблицы;
using DBPSA.Shared.Db.Services;
using DBPSA.Shared.Enums;
using DBPSA.Shared.Models;
using DBPSA.Shared2.Tests.Tests.Core.Db;
using DBPSA.Shared2.Tests.Tests.Core.Extensions;
using DBPSA.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Models.Создать__Логин__Тесты
{
    
    [TestFixture]
    public class Создать_Логин__Тесты : Init
    {
        [Test]
        public void Проверяем_конструктор_с_нулл_входными_данными()
        {
            ICommonService?[] сервисы = {
                null,
                new Common_Service(), 
            };

            EMPLOYEE?[] пользователи =
            {
                null,
                new EMPLOYEE(), 
                new EMPLOYEE
                {
                    id = -1
                },
                new EMPLOYEE
                {
                    id = 0
                },
            };

            ДанныеИзФормы_СозданияЛогина_модель?[] модели =
            {
                null,
                new ДанныеИзФормы_СозданияЛогина_модель(),
            };
            
            foreach (var сервис in сервисы)
                foreach (var пользователь in пользователи)
                    foreach (var модель in модели) 
                    {
                        Создать_Логин? unused = null;
                        
                        Assert.DoesNotThrow(() =>
                        {
                            unused = new Создать_Логин(сервис, пользователь, модель);
                        });
                        
                        Assert.IsNotNull(unused);
                        Assert.IsNotNull(unused?.Exception);
                        Assert.AreEqual(unused?.Exception?.GetType(), new ArgumentException().GetType());
                    }
        }

        [Test]
        public void Проверяем_конструктор_Создать_Логин_ид_пользователя_НЕ_валидно_модель_НЕ_валидна()
        {
            ICommonService сервис = new Common_Service();

            EMPLOYEE[] пользователи =
            {
                new EMPLOYEE{ id = -1 }, 
                new EMPLOYEE{ id = 0 },
            };
            
            ДанныеИзФормы_СозданияЛогина_модель модель = new ДанныеИзФормы_СозданияЛогина_модель();

            foreach (var пользователь in пользователи)
            {
                Создать_Логин? dummy = null;
                TestDelegate testDelegate = () =>
                {
                    dummy = new Создать_Логин(сервис, пользователь, модель);
                };   
              
                Assert.DoesNotThrow(testDelegate);
                Assert.IsNotNull(dummy?.Exception);
                Assert.AreEqual(dummy?.Exception?.GetType(), new ArgumentException().GetType());
            }
        }  
        
        [Test]
        public void Проверяем_конструктор_Создать_Логин_меняем_валидно_ид_пользователя_модель_из_конструктора_по_умолчанию()
        {
            ICommonService сервис = new Common_Service();

            EMPLOYEE[] пользователи =
            {
                new EMPLOYEE{ id = 1 }, 
                new EMPLOYEE{ id = _ID },
            };
            
            ДанныеИзФормы_СозданияЛогина_модель модель = new ДанныеИзФормы_СозданияЛогина_модель();

            foreach (var пользователь in пользователи)
            {
                TestDelegate testDelegate = () =>
                {
                    var dummy = new Создать_Логин(сервис, пользователь, модель);
                };   
                                        
                Assert.DoesNotThrow(testDelegate);    
            }
        }
        
        
        [Test]
        public void Проверяем_конструктор_на_НЕ_нулл_входных_данных_модель_не_валидна()
        {
            ICommonService сервис = new Common_Service();

            EMPLOYEE[] валидныеПользователи =
            {
                new EMPLOYEE{ id = 1 }, 
                new EMPLOYEE{ id = _ID },
            };

            string?[] неВалидныеСтроки = { null, "", "1" };
            int?[] неВалидныеЦелые = { null, -1, 0 };
            DateTime?[] неВалидныеДаты = { null, DateTime.MinValue, DateTime.MaxValue };
                
            {
                foreach (var целое1 in неВалидныеЦелые)
                foreach (var целое2 in неВалидныеЦелые)
                foreach (var строка1 in неВалидныеСтроки)
                foreach (var строка2 in неВалидныеСтроки)
                foreach (var дата in неВалидныеДаты)
                foreach (var пользователь in валидныеПользователи)
                {
                    Создать_Логин? dummy = null;
                    TestDelegate testDelegate = () =>
                    {
                        dummy = new Создать_Логин(сервис, пользователь, new ДанныеИзФормы_СозданияЛогина_модель
                        {
                            login_name = строка1,
                            email = строка2,
                            id_user = целое1,
                            id_domen = целое2,
                            date_time = дата
                        });
                        
                    };  
                    
                    StringHelper.Print(dummy);
                    Assert.DoesNotThrow(testDelegate);
                    
                    ДанныеИзФормы_СозданияЛогина_модель модель = new ДанныеИзФормы_СозданияЛогина_модель 
                    {
                        login_name = строка1,
                        email = строка2,
                        id_user = целое1,
                        id_domen = целое2,
                        date_time = дата
                    };
                    
                    var создатьЛогин = new Создать_Логин(сервис, пользователь, модель);
                    Assert.IsNotNull(создатьЛогин.Exception);

                    if (создатьЛогин.Exception!.Message.Contains("Ссылка на объект не указывает на экземпляр объекта"))
                    {
                        PrintTestContext(модель);
                        Assert.AreEqual(создатьЛогин.Exception?.Message, "");    
                    }
                    
                    Assert.True(создатьЛогин.Exception?.Message.Contains("Модель не валидна"));
                }    
            }
        }

        [Test]
        public void Создаем_логин_на_валидных_данных()
        {
            using var scope = _container?.BeginLifetimeScope() ?? throw new NullReferenceException();
            var commonService = scope.Resolve<ICommonService>() ?? throw new NullReferenceException();

            EMPLOYEE пользователь = new EMPLOYEE { id=_ID };
            var fixture = new Fixture();
            
            ДанныеИзФормы_СозданияЛогина_модель модель = new ДанныеИзФормы_СозданияЛогина_модель 
            {
                login_name = fixture.Create<string>().Substring(0, 20),
                email = ГенераторМоделей.ПолучитьВалидныйЕмайл(Annotation.email.MaxLength),
                id_user = пользователь.id,
                id_domen = 2,
                date_time = DateTime.Now
            };

            var создатьЛогин = new Создать_Логин(commonService, пользователь, модель);

            Assert.IsNotNull(создатьЛогин);
            
            var exception = создатьЛогин.Exception;
            Assert.IsNull(exception);
            
            var заявка = создатьЛогин.ПолучитьЗаявку();
            var логин = создатьЛогин.ПолучитьЛогин();
            
            Console.WriteLine($@"code = {StringHelper.Print(создатьЛогин.ПолучитьРезультат()?.code)}");
            Console.WriteLine(создатьЛогин.ПолучитьРезультат()?.msg);
            Console.WriteLine($@"ид заявки: {StringHelper.Print(заявка?.id)}");
            Console.WriteLine($@"ид логина: {StringHelper.Print(логин?.id)}");
            
            Assert.AreEqual(создатьЛогин.ПолучитьРезультат()?.code, 200);
            Assert.IsTrue(создатьЛогин.ПолучитьРезультат()?.msg.Contains("успешно создан"));
            
            Assert.GreaterOrEqual(логин?.id, 1);
            Assert.GreaterOrEqual(заявка?.id, 1);
        }
    }
}