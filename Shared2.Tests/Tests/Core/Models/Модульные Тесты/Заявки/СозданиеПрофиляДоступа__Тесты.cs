using AutoFixture;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NSubstitute;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.Заявки
{
    [TestFixture]
    public class СозданиеПрофиляДоступа__Тесты : InitModule
    {
        [Test]
        public void Создаем_валидный_конструктор__Не_бросает_исключение__Возвращает_валидный_результат()
        {
            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CRPROFILEOBJECTS")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Заявка на создание профиля доступа",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CRPROFILEOBJECTS",
                });
            
            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CREATE_PROFILE")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Создание сущности PROFILE",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CREATE_PROFILE",
                });
            
            var модель = new ДанныеИзФормы_СозданиеПрофиляДоступа_модель
            {
                id = null,
                ProfileName = ПолучитьФикстуру<string>(),
                ResourceObjectId = 1709,
                ProfileObjects = new ProfileObject?[]
                {
                    new ProfileObject
                    {
                        ObjectName = ПолучитьФикстуру<string>(),
                        ObjectTypeId = 1,
                        RightDescriptions = new int?[] {14, 15, 16}
                    }
                },
                request_params = ПолучитьВалиднуюМодель_RequestParams(логинПользователяСервиса)
            };

            СозданиеПрофиляДоступаНаЗащищаемыйРесурс? профильДоступаНаЗащищаемыйРесурс = null;
            object? jsonМодель = null;
            TestDelegate testDelegate = () =>
            {
                профильДоступаНаЗащищаемыйРесурс = new СозданиеПрофиляДоступаНаЗащищаемыйРесурс(
                    _commonService,
                    log,
                    модель.request_params?.sender_login,
                    модель,
                    null
                );

                jsonМодель = профильДоступаНаЗащищаемыйРесурс.ПолучитьJsonМодель();
            };

            Assert.DoesNotThrow(testDelegate);
            Helper.AssertResults(testDelegate, профильДоступаНаЗащищаемыйРесурс, jsonМодель);
            
            var requestId = профильДоступаНаЗащищаемыйРесурс?.ProfileStruct.Request?.id;
            Assert.IsTrue(requestId > 0);

            var objects = профильДоступаНаЗащищаемыйРесурс?.ProfileStruct.Objects;
            Assert.IsNotNull(objects);


            Assert.IsTrue(objects?.TrueForAll(r => r != null));
            Assert.IsTrue(objects?.TrueForAll(r => r.Object != null));
            Assert.IsTrue(objects?.TrueForAll(r => r.Object?.id > 0));
            Assert.IsTrue(objects?.TrueForAll(r => r.Object?.id_request_1 > 0));
                
            Assert.IsTrue(objects?.TrueForAll(r => r.Rights != null));
            Assert.IsTrue(objects?.TrueForAll(r => r.Rights!.TrueForAll(right 
                    => 
                    right != null
                    && right.id > 0
                    && right.id_request_1 > 0
            )));

            var prop0 = jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[0].Name;
            Assert.True(prop0 == "_request", $"Property[0].Name: {prop0}");
            
            var prop1 = jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[1].Name;
            Assert.True(prop1 == "_profile", $"Property[1].Name: {prop1}");
        }
    }
}