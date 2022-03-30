using System;
using System.Linq.Expressions;
using AutoFixture;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Doc;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NSubstitute;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.Заявки
{
    [TestFixture]
    public class СозданиеЗащищаемогоРесурсаЗЛИВС__Тесты : InitModule
    {
        [Test]
        public void Создаем_валидный_конструктор__Не_бросает_исключение__Возвращает_валидный_результат()
        {
            _commonService
                .ПолучитьТипЗаявкиПоИмениТипа("CRRESZLIVS")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Создание защищаемого ресурса",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CRRESZLIVS",
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
                .ПолучитьТипЗаявкиПоИмениТипа("CREATE_RESOURCE_MEMBER")
                .Returns(new REQUEST_TYPE
                {
                    id = ПолучитьФикстуру<int>(),
                    name = "Создание сущности RESOURCE_MEMBER",
                    sdescription = string.Empty,
                    id_parent = null,
                    maintenance = null,
                    code = "CREATE_RESOURCE_MEMBER",
                });

            _commonService
                .ПолучитьОбъектРесурса(Arg.Any<Func<OBJECT, bool>>())
                .Returns(_ => null);
            
            _commonService
                .ПолучитьРесурсИзПредставления(Arg.Any<Func<VIEW_REPORT_ALL_RESOURCES, bool>>())
                .Returns(v => { return new VIEW_REPORT_ALL_RESOURCES();});

            _commonService
                .ПолучитьСотрудниковДопущенныхКоРесурсуЗЛИВС(Arg.Any<Expression<Func<VIEW_RESOURCE_MEMBER_EMPLOYEE, bool>>>())
                .Returns(Array.Empty<VIEW_RESOURCE_MEMBER_EMPLOYEE>());
            
            var модель = new ДанныеИзФормы_СозданиеЗащищаемогоРесурсаЗЛИВС_модель
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
                OwnerId = 3,
                UserIds = new int?[]{1},
                OrgIds = new int?[]{1}
            };

            СозданиеЗащищаемогоРесурсаЗЛИВС? созданиеЗащищаемогоРесурсаЗливс = null;
            object? jsonМодель = null;
            TestDelegate t1 = () =>
            {
                созданиеЗащищаемогоРесурсаЗливс = new СозданиеЗащищаемогоРесурсаЗЛИВС(
                    _commonService, 
                    new DocPaths(),
                    log,
                    модель.request_params.sender_login,
                    модель,
                    null
                );
            };
            
            TestDelegate t2 = () => jsonМодель = созданиеЗащищаемогоРесурсаЗливс?.ПолучитьJsonМодель();
            
            Assert.DoesNotThrow(t1);
            Assert.DoesNotThrow(t2);
            
            Helper.AssertResults(t1, созданиеЗащищаемогоРесурсаЗливс, jsonМодель);

            var requestId = созданиеЗащищаемогоРесурсаЗливс?.request?.id;
            Assert.IsTrue(requestId > 0);

            var объектРесурса = созданиеЗащищаемогоРесурсаЗливс?.объектРесурса;
     
            Assert.IsTrue(объектРесурса?.id > 0);
            Assert.IsTrue(объектРесурса?.id_request_1 > 0);
            
            var защищаемыйРесурс = созданиеЗащищаемогоРесурсаЗливс?.ресурс;
            
            Assert.IsTrue(защищаемыйРесурс?.id > 0);
            Assert.IsTrue(защищаемыйРесурс?.id_request_1 > 0);
            
            var resourceMembers = созданиеЗащищаемогоРесурсаЗливс?.resourceMembers;
            
            Assert.IsTrue(resourceMembers != null);
            Assert.IsTrue(resourceMembers!.Count == 2);
            
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[0].Name == "_request");
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[1].Name == "_resource");
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[2].Name == "_object");
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[3].Name == "_members");
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[4].Name == "_doc");
        }
    }
}