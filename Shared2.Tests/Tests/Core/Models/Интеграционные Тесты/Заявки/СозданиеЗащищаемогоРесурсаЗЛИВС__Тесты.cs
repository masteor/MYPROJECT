using AutoFixture;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;
using static QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.InitModule;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Интеграционные_Тесты.Заявки
{
    [TestFixture]
    public class СозданиеЗащищаемогоРесурсаЗЛИВС__Тесты : Init
    {
        [Test]
        public void Создаем_валидный_конструктор__Не_бросает_исключение__Возвращает_валидный_результат()
        {
            var модель = new ДанныеИзФормы_СозданиеЗащищаемогоРесурсаЗЛИВС_модель
            {
                id = null,
                request_params = new RequestParams
                {
                    create_date_time = null,
                    end_date_time = null,
                    sender_login = "kirillovanm",
                    recipient_login = null,
                    request_state_id = 1,
                    doc = new byte?[]
                    {
                    },
                    reg_number = null,
                    parent = null
                },
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
                UserIds = new int?[]{1,2,3},
                OrgIds = new int?[]{1,2,3}
            };

            СозданиеЗащищаемогоРесурсаЗЛИВС? защищаемогоРесурсаЗливс = null;
            object? jsonМодель = null;
            TestDelegate t1 = () =>
            {
                защищаемогоРесурсаЗливс = new СозданиеЗащищаемогоРесурсаЗЛИВС(
                    CommonService,
                    docPaths,
                    Log,
                    модель.request_params.sender_login,
                    модель,
                    null
                );
            };
            
            TestDelegate t2 = () => jsonМодель = защищаемогоРесурсаЗливс?.ПолучитьJsonМодель();
            
            Assert.DoesNotThrow(t1);
            Assert.DoesNotThrow(t2);
            
            Helper.AssertResults(t1, защищаемогоРесурсаЗливс, jsonМодель);

            var requestId = защищаемогоРесурсаЗливс?.request?.id;
            Assert.IsTrue(requestId > 0);

            var объектРесурса = защищаемогоРесурсаЗливс?.объектРесурса;
            Assert.IsTrue(объектРесурса?.id > 0);
            Assert.IsTrue(объектРесурса?.id_request_1 > 0);
            Assert.IsTrue(объектРесурса?.id_request_1 > requestId);

            var защищаемыйРесурс = защищаемогоРесурсаЗливс?.ресурс;
            Assert.IsTrue(защищаемыйРесурс?.id > 0);
            Assert.IsTrue(защищаемыйРесурс?.id_request_1 > 0);
            Assert.IsTrue(защищаемыйРесурс?.id_request_1 > requestId);

            var док = защищаемогоРесурсаЗливс?.doc;
            Assert.IsTrue(док?.id > 0);
            Assert.IsTrue(док?.id_request_1 > 0);
            Assert.IsTrue(док?.id_request_1 > requestId);
            
            Assert.False(защищаемогоРесурсаЗливс?.ПроизошлаОшибка);
            
            /*Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[0].Name == "_resource");
            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[1].Name == "_object");*/
        }
    }
}