using System;
using AutoFixture;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NSubstitute;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.Заявки
{
    [TestFixture]
    public class СозданиеЗащищаемогоРесурса__Тесты : InitModule
    {
        [Test]
        public void Создаем_валидный_конструктор__Не_бросает_исключение__Возвращает_валидный_результат()
        {
            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CRRES")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Создание защищаемого ресурса",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CRRES",
                });
            
            
            
            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CREATE_RESOURCE")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Создание сущности ресурс",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CREATE_RESOURCE",
                });

            _commonService
                .ПолучитьОбъектРесурса(Arg.Any<Func<OBJECT, bool>>())
                .Returns(_ => null);
            
            var модель = new ДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель
            {
                id = null,
                request_params = ПолучитьВалиднуюМодель_RequestParams(логинПользователяСервиса),
                ParentObjectId = null,
                NewId = null,
                path = null,
                description = null,
                ObjectTypeId = 1,
                ObjectId = null,
                FragmentId = 1,
                ServiceTypeId = 1,
                ObjectName = ПолучитьФикстуру<string>(),
                SecretTypeId = 6,
                ResponsibleId = 2,
                OwnerId = 3
            };

            СозданиеЗащищаемогоРесурса? созданиеЗащищаемогоРесурса = null;
            object? jsonМодель = null;
            TestDelegate t1 = () =>
            {
                созданиеЗащищаемогоРесурса = new СозданиеЗащищаемогоРесурса(
                    _commonService,
                    log,
                    модель.request_params.sender_login,
                    модель,
                    null
                );
            };
            
            TestDelegate t2 = () => jsonМодель = созданиеЗащищаемогоРесурса?.ПолучитьJsonМодель();
            
            Assert.DoesNotThrow(t1);
            Assert.DoesNotThrow(t2);
            
            Helper.AssertResults(t1, созданиеЗащищаемогоРесурса, jsonМодель);

            var requestId = созданиеЗащищаемогоРесурса?.request?.id;
            Assert.IsTrue(requestId > 0);

            var объектРесурса = созданиеЗащищаемогоРесурса?.объектРесурса;
     
            Assert.IsTrue(объектРесурса?.id > 0);
            Assert.IsTrue(объектРесурса?.id_request_1 > 0);
            
            var защищаемыйРесурс = созданиеЗащищаемогоРесурса?.ресурс;
            
            Assert.IsTrue(защищаемыйРесурс?.id > 0);
            Assert.IsTrue(защищаемыйРесурс?.id_request_1 > 0);
            
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[0].Name == "_request");
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[1].Name == "_resource");
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[2].Name == "_object");
        }
    }
}