using System;
using System.Linq;
using AutoFixture;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models;
using log4net;
using NSubstitute;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты
{
    [TestFixture]
    public class InitModuleТесты : InitModule
    {
        [SetUp]
        public void Инициализация()
        {
            
        }

        [Test]
        public void Свойства_Инициализированы()
        {
            Assert.NotNull(РодительскаяЗаявка);
            Assert.NotNull(ПользовательСервиса);
            Assert.NotNull(ЛогинПользователяСервиса);
            Assert.NotNull(емайлПользователяСервиса);
            Assert.IsNotNull(РодительскаяЗаявка);
            
            Assert.IsTrue(идПользователяСервиса > 0);
            Assert.IsTrue(идДругогоПользователяСервиса > 0);
            Assert.IsFalse(string.IsNullOrWhiteSpace(буквенныйКодСтатусаЗаявки));
            Assert.IsNotNull(типыЗаявок);
            Assert.NotNull(_commonService);
            Assert.IsInstanceOf<ICommonService>(_commonService);
            
            Assert.NotNull(log);
            Assert.IsInstanceOf<ILog>(log);
        }


        [Test]
        public void ПолучитьВалиднуюМодель_ДанныеИзФормы__ВозвращаетТребуемоеЗначение()
        {
            Assert.IsNull(ПолучитьВалиднуюМодель_ДанныеИзФормы().id);            
            Assert.IsNotNull(ПолучитьВалиднуюМодель_ДанныеИзФормы().request_params);
            
            Assert.IsTrue(ПолучитьВалиднуюМодель_ДанныеИзФормы().Валидна());
        }

        [Test]
        public void ПолучитьВалиднуюМодель_RequestParams_ДанныеИзФормы__ВозвращаетТребуемоеЗначение()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(ПолучитьВалиднуюМодель_RequestParams().sender_login));

            var s = ПолучитьФикстуру<string>();
            Assert.AreEqual(s, ПолучитьВалиднуюМодель_RequestParams(s).sender_login);
        }
        
        [Test]
        public void ПолучитьЛогинПоИмениЛогина_Заглушка_Тест__Не_бросает_исключение__Возвращает_требуемое_значение()
        {
            Assert.IsNotNull(_commonService.ПолучитьЛогинПоИмениЛогина(ЛогинПользователяСервиса.name));
            Assert.AreEqual(ЛогинПользователяСервиса.name,
                _commonService.ПолучитьЛогинПоИмениЛогина(ЛогинПользователяСервиса.name)?.name);
            Assert.Null(_commonService.ПолучитьЛогинПоИмениЛогина(ПолучитьФикстуру<string>()));
        }
        
        [Test]
        public void ПолучитьПользователя_Заглушка_Тест__Не_бросает_исключение__Возвращает_требуемое_значение()
        {
            Assert.IsNotNull(_commonService.ПолучитьПользователяПоИд(идПользователяСервиса));
            Assert.AreEqual(идПользователяСервиса, _commonService.ПолучитьПользователяПоИд(идПользователяСервиса)?.id);
            
            Assert.Null(_commonService.ПолучитьПользователяПоИд(идДругогоПользователяСервиса));
            Assert.AreNotEqual(идДругогоПользователяСервиса, _commonService.ПолучитьПользователяПоИд(идДругогоПользователяСервиса)?.id);
        }
        
        [Test]
        public void ПолучитьТипЗаявкиПоИмениТипа_Заглушка_Тест__Не_бросает_исключение__Возвращает_требуемое_значение()
        {
            foreach (var rt in типыЗаявок)
            {
                Assert.AreEqual(rt.id, _commonService.ПолучитьТипЗаявкиПоИмениТипа(rt.code ?? string.Empty)?.id);    
            }

            var неСуществующийБуквенныйКодТипаЗаявки = ПолучитьФикстуру<string>();
            Assert.Null(_commonService.ПолучитьТипЗаявкиПоИмениТипа(неСуществующийБуквенныйКодТипаЗаявки));
            Assert.AreNotEqual(неСуществующийБуквенныйКодТипаЗаявки, _commonService.ПолучитьТипЗаявкиПоИмениТипа(неСуществующийБуквенныйКодТипаЗаявки)?.id);
        }

        [Test]
        public void НайтиСтатусЗаявкиПоКоду_Заглушка_Тест__Не_бросает_исключение__Возвращает_требуемое_значение()
        {
            Assert.IsNotNull(_commonService.ПолучитьСтатусЗаявкиПоКоду(буквенныйКодСтатусаЗаявки));
            
            Assert.AreEqual(буквенныйКодСтатусаЗаявки, 
                _commonService.ПолучитьСтатусЗаявкиПоКоду(буквенныйКодСтатусаЗаявки).code);
        }

        [Test]
        public void ДобавитьВоМодельКорректный_request_params_sender_login__НеВалиднаяМодель_БросаетИсключение()
        {
            Assert.Throws<ArgumentNullException>(() => 
                ДобавитьВоМодельКорректный_request_params_sender_login(new ДанныеИзФормы
            {
                id = null,
                request_params = null
            }));
        }

        [Test]
        public void СоздатьНовыйСписок_REQUEST__ПередаемВалидныеЗначения__ПолучаемВалидныйРезультат()
        {
            var идТекущегоСтатусаЗаявки = (int) ИдСтатусаЗаявки.Зарегистрирована;
            var arr = new[] {3, 2, 1};
            var requests = СоздатьНовыйСписок_REQUEST(arr, идТекущегоСтатусаЗаявки);

            Assert.True(requests
                .TrueForAll(r 
                    => r.id_request_state == идТекущегоСтатусаЗаявки));
            
            Assert.True(requests
                .Select((r, i) => r.id == arr[i])
                .All(b => b));
        }
    }
}