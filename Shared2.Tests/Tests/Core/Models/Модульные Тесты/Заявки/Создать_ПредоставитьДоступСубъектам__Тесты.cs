using System;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам;
using NSubstitute;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.Заявки
{
    [TestFixture]
    public sealed class Создать_ПредоставитьДоступСубъектам__Тесты : InitModule
    {
        public delegate bool ProfileDelegate(Func<PROFILE> profile);
        
        [SetUp]
        public void ИнициализацияЗаглушек()
        {
            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа(null)
                .Returns(new REQUEST_TYPE
                {
                    id = -1 
                });
        }
        
        
        [Test]
        public void Создаем_валидный_конструктор__Не_бросает_исключение__Возвращает_валидный_результат111()
        {
            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CRMEMBER")
                .Returns(new REQUEST_TYPE
                {
                    id = 1,
                    name = "Заявка на предоставление субъектам прав доступа к ресурсу",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CRMEMBER",
                });

            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CREATE_MEMBER")
                .Returns(new REQUEST_TYPE
                {
                    id = 2,
                    name = "Создание сущности MEMBER",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CREATE_MEMBER",
                });


            var profile = ПолучитьФикстуру_PROFILE();

            _commonService
                .ПолучитьПрофиль(Arg.Any<Func<PROFILE, bool>>())
                .ReturnsForAnyArgs(_ => profile);
            
            Assert.AreEqual(_commonService
                .ПолучитьПрофиль(_ => true)?.name, profile.name);

            var модель = new ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель
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
                        РодительскаяЗаявка
                    );

            // Ассерты
            
            Assert.DoesNotThrow(Создать_ПредоставитьДоступСубъектам__Тест, 
                предоставитьДоступСубъектам?.Ошибка?.Message);
            
            Assert.IsNull(предоставитьДоступСубъектам?.Ошибка);
            Assert.IsFalse(предоставитьДоступСубъектам?.ПроизошлаОшибка);
        }
    }
}