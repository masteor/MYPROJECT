using System;
using AutoFixture;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам;
using QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Интеграционные_Тесты.Заявки
{
    [TestFixture]
    public class Создать_ПредоставитьДоступСубъектам__Тесты : InitModule
    {
        private readonly ICommonService _commonService = Substitute.For<ICommonService>();
        private readonly log4net.ILog log = Substitute.For<log4net.ILog>();
        private readonly LOGIN ЛогинПользователяСервиса = new LOGIN
        {
            id = 1111,
            name = "kirillovanm",
            email = "kirillovanm@sils.local",
            id_user = идПользователяСервиса,
            id_domen = 0,
            id_request_0 = null,
            id_request_1 = null,
            id_request_2 = null,
            is_active = true
        };

        private readonly EMPLOYEE ПользовательСервиса = new EMPLOYEE
        {
            id = идПользователяСервиса,
            tnum = null,
            id_job = null,
            id_form_perm = null,
            id_fio = null,
            job_begin_date = null,
            job_end_date = null,
            ид_актуальной_записи = null,
            ид_заявки_создания = null,
            ид_заявки_удаления = null,
        };
        
        private const int идПользователяСервиса = 2222;
        private const int идДругогоПользователяСервиса = 2233;
        private const int идТипаЗаявки = 3333;
        private readonly string буквенныйКодСтатусаЗаявки = БуквенныеКодыСтатусовЗаявок.Зарегистрирована;
        
        private readonly REQUEST? родительскаяЗаявка = null;
        private const string буквенныйКодТипаЗаявки = БуквенныеКодыТиповЗаявок.ЗаявкаНаПредоставлениеДоступаСубъектам;

        [SetUp]
        public void ИнициализацияЗаглушек()
        {
            throw new NotImplementedException("Переделать в интеграционный тест");
            
            _commonService
                .ПолучитьЛогинПоИмениЛогина(ЛогинПользователяСервиса.name)
                .Returns(ЛогинПользователяСервиса);
            
            _commonService.ПолучитьПользователяПоИд(идПользователяСервиса).Returns(ПользовательСервиса);

            _commonService.ПолучитьТипЗаявкиПоИмениТипа(буквенныйКодТипаЗаявки).Returns(new REQUEST_TYPE
            {
                id = идТипаЗаявки
            });

            _commonService.ПолучитьСтатусЗаявкиПоКоду(буквенныйКодСтатусаЗаявки).Returns(
                new REQUEST_STATE
                {
                    id = 77,
                    name = ПолучитьФикстуру<string>(),
                    code = буквенныйКодСтатусаЗаявки
                });

            _commonService.ПолучитьСтатусЗаявкиПоКоду(
                Arg.Is<string>(s => !string.Equals(s, буквенныйКодСтатусаЗаявки,
                StringComparison.OrdinalIgnoreCase)))
                .Throws(new InvalidOperationException($"код статуса заявки не найден"));
            
            _commonService.Создать(Arg.Any<REQUEST>()).Returns(arg =>
            {
                var request = ((REQUEST) arg[0]);
                request.id = (int) ПолучитьФикстуру<uint>();
                return request;
            });
        }

        /*[Test]
        public void ПолучитьЛогинПоИмениЛогина_Заглушка_Тест__Не_бросает_исключение__Возвращает_требуемое_значение()
        {
            Assert.IsNotNull(_commonService.ПолучитьЛогинПоИмениЛогина(ЛогинПользователяСервиса.name));
            Assert.AreEqual(ЛогинПользователяСервиса.name,
                _commonService.ПолучитьЛогинПоИмениЛогина(ЛогинПользователяСервиса.name)?.name);
            Assert.Null(_commonService.ПолучитьЛогинПоИмениЛогина(ПолучитьФикстуру<string>()));
        }*/


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
            Assert.IsNotNull(_commonService.ПолучитьТипЗаявкиПоИмениТипа(буквенныйКодТипаЗаявки));
            Assert.AreEqual(идТипаЗаявки, _commonService.ПолучитьТипЗаявкиПоИмениТипа(буквенныйКодТипаЗаявки)?.id);

            var неСуществующийБуквенныйКодТипаЗаявки = ПолучитьФикстуру<string>();
            Assert.Null(_commonService.ПолучитьТипЗаявкиПоИмениТипа(неСуществующийБуквенныйКодТипаЗаявки));
            Assert.AreNotEqual(неСуществующийБуквенныйКодТипаЗаявки, _commonService.ПолучитьТипЗаявкиПоИмениТипа(неСуществующийБуквенныйКодТипаЗаявки)?.id);
        }

        /*[Test]
        public void НайтиСтатусЗаявкиПоКоду_Заглушка_Тест__Не_бросает_исключение__Возвращает_требуемое_значение()
        {
            Assert.IsNotNull(_commonService.НайтиСтатусЗаявкиПоКоду(буквенныйКодСтатусаЗаявки));
            Assert.AreEqual(буквенныйКодСтатусаЗаявки, _commonService.НайтиСтатусЗаявкиПоКоду(буквенныйКодСтатусаЗаявки).code);
            
            Assert.Throws<InvalidOperationException>(() => _commonService.НайтиСтатусЗаявкиПоКоду(ПолучитьФикстуру<string>()));
        }*/
        
        
        [Test]
        public void Создаем_валидный_конструктор__Не_бросает_исключение__Возвращает_валидный_результат()
        {
            
            ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель? модель = new ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель
            {
                id = null,
                ProfileId = 111,
                UserIds = new int?[]{1,2,3},
                OrgIds = new int?[]{11,22,33},
                request_params = new RequestParams
                {
                    create_date_time = null,
                    end_date_time = null,
                    sender_login = ЛогинПользователяСервиса.name,
                    recipient_login = null,
                    request_state_id = null,
                    doc = null,
                    reg_number = null,
                    parent = null
                }
            };

            Создать_ПредоставитьДоступСубъектам? предоставитьДоступСубъектам = null;
            void Создать_ПредоставитьДоступСубъектам__Тест() 
                => предоставитьДоступСубъектам = 
                    new Создать_ПредоставитьДоступСубъектам
                    (
                        _commonService,
                        log,
                        модель.request_params.sender_login,
                        модель,
                        родительскаяЗаявка
                    );

            // Ассерты
            
            Assert.DoesNotThrow(Создать_ПредоставитьДоступСубъектам__Тест, предоставитьДоступСубъектам?.Ошибка?.Message);
            Assert.IsNotNull(предоставитьДоступСубъектам?.Ошибка);

            Assert.IsFalse(предоставитьДоступСубъектам?.ПроизошлаОшибка);
        }
    }
}