using AutoFixture;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;
using static QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.InitModule;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Интеграционные_Тесты.Заявки
{
    [TestFixture]
    public class СозданиеПрофиляДоступа__Тесты : Init
    {
        [Test]
        public void Создаем_валидный_конструктор__Не_бросает_исключение__Возвращает_валидный_результат()
        {
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
                }
            };

            СозданиеПрофиляДоступаНаЗащищаемыйРесурс? профиляДоступа = null;
            object? jsonМодель = null;
            
            TestDelegate testDelegate = () =>
            {
                профиляДоступа = new СозданиеПрофиляДоступаНаЗащищаемыйРесурс(
                    CommonService,
                    Log,
                    модель.request_params?.sender_login,
                    модель,
                    null
                );

                jsonМодель = профиляДоступа.ПолучитьJsonМодель();
            };

            Assert.DoesNotThrow(testDelegate);
            Helper.AssertResults(testDelegate, профиляДоступа, jsonМодель);
            
            var requestId = профиляДоступа?.ProfileStruct.Request?.id;
            Assert.IsTrue(requestId > 0);

            var objects = профиляДоступа?.ProfileStruct.Objects;
            Assert.IsNotNull(objects);


            Assert.IsTrue(objects?.TrueForAll(r => r != null));
            Assert.IsTrue(objects?.TrueForAll(r => r.Object != null));
            Assert.IsTrue(objects?.TrueForAll(r => r.Object?.id > 0));
            Assert.IsTrue(objects?.TrueForAll(r => r.Object?.id_request_1 > 0));
                
            Assert.IsTrue(objects?.TrueForAll(r => r.Rights != null));
            Assert.IsTrue(objects?.TrueForAll(r => r.Rights.TrueForAll(right 
                    => 
                    right != null
                    && right.id > 0
                    && right.id_request_1 > 0
            )));
            
            Assert.False(профиляДоступа?.ПроизошлаОшибка);
            
//            Assert.True(jsonМодель?.GetType().GetProperties()[0].GetValue(jsonМодель).GetType().GetProperties()[0].Name == "_profile");
        }
    }
}