using QWERTY.Shared.Extensions;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.ВалидацияМоделей
{
    [TestFixture]
    public class Валидация_ДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель__Тесты : InitModule, IМоделиТесты
    {
        [Test]
        public void НеВалиднаяМодель()
        {
            {
                var модель = new ДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель
                {
                    id = null,
                    request_params = null,
                    ParentObjectId = null,
                    NewId = null,
                    path = null,
                    description = null,
                    ObjectTypeId = null,
                    ObjectId = null,
                    FragmentId = null,
                    ServiceTypeId = null,
                    ObjectName = null,
                    SecretTypeId = null,
                    ResponsibleId = null,
                    OwnerId = null
                };

                Assert.True(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }
            
            {
                var модель = new ДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель
                {
                    id = null,
                    request_params = new RequestParams("sd"),
                    ParentObjectId = null,
                    NewId = null,
                    path = null,
                    description = null,
                    ObjectTypeId = null,
                    ObjectId = null,
                    FragmentId = null,
                    ServiceTypeId = null,
                    ObjectName = null,
                    SecretTypeId = null,
                    ResponsibleId = null,
                    OwnerId = null
                };

                Assert.True(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }
        }

        [Test]
        public void ВалиднаяМодель()
        {
            {
                var модель = new ДанныеИзФормы_СозданиеЗащищаемогоРесурса_модель
                {
                    id = null,
                    request_params = new RequestParams("rvftbgyhunjmik"),
                    ParentObjectId = null,
                    NewId = null,
                    path = null,
                    description = null,
                    ObjectTypeId = 1,
                    ObjectId = null,
                    FragmentId = 1,
                    ServiceTypeId = 1,
                    ObjectName = "ab",
                    SecretTypeId = 1,
                    ResponsibleId = 1,
                    OwnerId = 1
                };

                Assert.IsTrue(модель.Валидна(), модель.получитьИсключение?.Message);
                Assert.IsNull(модель.получитьИсключение?.Message);
            }
        }
    }
}