using System;
using Autofac;
using AutoFixture;
using DBPSA.Shared.Db.Entities.Таблицы;
using DBPSA.Shared.Db.Infrastructure;
using DBPSA.Shared.Db.Repositories;
using DBPSA.Shared.Db.Services;
using DBPSA.Shared.Models;
using DBPSA.Shared2.Tests.Tests.Core.Db;
using DBPSA.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Models.Создать__ФИО__Тесты
{
    [TestFixture]
    public class Создать__ФИО__Тесты : Init
    {
        [Test]
        public void Проверяем_конструктор_с_нулл_входными_данными()
        {
            ICommonService?[] сервисы = {
                null,
                new Common_Service(new VIEW_FIO_Repository(DB_FACTORY)), 
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

            ДанныеИзФормы_СозданияФИО_модель?[] модели =
            {
                null,
                new ДанныеИзФормы_СозданияФИО_модель(),
            };
            
            foreach (var сервис in сервисы)
            foreach (var пользователь in пользователи)
            foreach (var модель in модели) 
            {
                Создать_ФИО? unused = null;
                TestDelegate testDelegate = () =>
                {
                    unused = new Создать_ФИО (
                        сервис, 
                        Log,
                        "Не валидный логин пользователя сервиса", 
                        модель,
                        null
                    );
                };   
                            
                Assert.DoesNotThrow(testDelegate);
                Assert.IsNotNull(unused?.Exception);
                Assert.AreEqual(unused?.Exception?.GetType(), new ArgumentException().GetType());
            }
        }

        [Test]
        public void Проверяем_конструктор_Создать_ФИО_ид_пользователя_НЕ_валидно_модель_НЕ_валидна()
        {
            ICommonService сервис = new Common_Service();

            EMPLOYEE[] пользователи =
            {
                new EMPLOYEE{ id = -1 }, 
                new EMPLOYEE{ id = 0 },
            };
            
            var модель = new ДанныеИзФормы_СозданияФИО_модель();

            foreach (var пользователь in пользователи)
            {
                Создать_ФИО? dummy = null;
                TestDelegate testDelegate = () =>
                {
                    dummy = new Создать_ФИО(сервис, пользователь, модель);
                };   
              
                Assert.DoesNotThrow(testDelegate);
                Assert.IsNotNull(dummy?.Exception);
                Assert.AreEqual(dummy?.Exception?.GetType(), new ArgumentException().GetType());
            }
        }  
        
        [Test]
        public void Проверяем_конструктор_Создать_ФИО_меняем_валидно_ид_пользователя_модель_из_конструктора_по_умолчанию()
        {
            ICommonService сервис = new Common_Service();

            EMPLOYEE[] пользователи =
            {
                new EMPLOYEE{ id = 1 }, 
                new EMPLOYEE{ id = _ID },
            };
            
            var модель = new ДанныеИзФормы_СозданияФИО_модель();

            foreach (var пользователь in пользователи)
            {
                TestDelegate testDelegate = () =>
                {
                    var dummy = new Создать_ФИО(сервис, пользователь, модель);
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

            string?[] неВалидныеСтроки = { null, "" };
            DateTime?[] неВалидныеДаты = { null, DateTime.MinValue, DateTime.MaxValue };
                
            {
                foreach (var строка1 in неВалидныеСтроки)
                foreach (var строка2 in неВалидныеСтроки)
                foreach (var строка3 in неВалидныеСтроки)
                foreach (var дата in неВалидныеДаты)
                foreach (var пользователь in валидныеПользователи)
                {
                    Создать_ФИО? dummy = null;
                    TestDelegate testDelegate = () =>
                    {
                        dummy = new Создать_ФИО(сервис, пользователь, new ДанныеИзФормы_СозданияФИО_модель
                        {
                            family = строка1,
                            name = строка2,
                            patronymic = строка3,
                            date_time = дата
                        });
                    };  
                    
                    StringHelper.Print(dummy);
                    Assert.DoesNotThrow(testDelegate);
                    
                    var модель = new ДанныеИзФормы_СозданияФИО_модель
                    {
                        family = строка1,
                        name = строка2,
                        patronymic = строка3,
                        date_time = дата
                    };
                    
                    var создатьФио = new Создать_ФИО(сервис, пользователь, модель);
                    Assert.IsNotNull(создатьФио.Exception);

                    if (создатьФио.Exception!.Message.Contains("Ссылка на объект не указывает на экземпляр объекта"))
                    {
                        PrintTestContext(модель);
                        Assert.AreEqual(создатьФио.Exception?.Message, "");    
                    }
                    
                    Assert.True(создатьФио.Exception?.Message.Contains("Модель не валидна"));
                }    
            }
        }

        [Test]
        public void Создаем_ФИО_на_валидных_данных()
        {
            using var scope = _container?.BeginLifetimeScope() ?? throw new NullReferenceException();
            var commonService = scope.Resolve<ICommonService>() ?? throw new NullReferenceException();

            EMPLOYEE пользователь = new EMPLOYEE { id=_ID };
            var fixture = new Fixture();
            
            var модель = new ДанныеИзФормы_СозданияФИО_модель
            {
                family = fixture.Create<string>(),
                name = fixture.Create<string>(),
                patronymic = fixture.Create<string>(),
                date_time = DateTime.Now
            };
            
            var создатьФио = new Создать_ФИО(commonService, пользователь, модель);

            Assert.IsNotNull(создатьФио);
            
            var exception = создатьФио.Exception;
            Assert.IsNull(exception);
            
            var заявка = создатьФио.ПолучитьЗаявку();
            var фио = создатьФио.Фио();
            
            Console.WriteLine($@"code = {StringHelper.Print(создатьФио.ПолучитьРезультат()?.code)}");
            Console.WriteLine(создатьФио.ПолучитьРезультат()?.msg);
            Console.WriteLine($@"ид заявки: {StringHelper.Print(заявка?.id)}");
            Console.WriteLine($@"ид фио: {StringHelper.Print(фио?.id)}");
            
            Assert.AreEqual(создатьФио.ПолучитьРезультат()?.code, 200);
            Assert.IsTrue(создатьФио.ПолучитьРезультат()?.msg.Contains("успешно создан"));
            
            Assert.GreaterOrEqual(фио?.id, 1);
            Assert.GreaterOrEqual(заявка?.id, 1);
        }
    }
}