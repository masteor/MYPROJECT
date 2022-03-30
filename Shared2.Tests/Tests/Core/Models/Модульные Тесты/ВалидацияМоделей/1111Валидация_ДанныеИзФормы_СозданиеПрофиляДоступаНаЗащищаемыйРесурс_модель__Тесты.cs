using System.Linq;
using DBPSA.Shared.Extensions;
using DBPSA.Shared.Models;
using DBPSA.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс;
using DBPSA.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace DBPSA.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.ВалидацияМоделей
{
    [TestFixture]
    public class Валидация_ДанныеИзФормы_СозданиеПрофиляДоступаНаЗащищаемыйРесурс_модель__Тесты : IМоделиТесты
    {
        [Test]
        public void НеВалиднаяМодель()
        {
            var модель1 = new ДанныеИзФормы_СозданиеПрофиляДоступа_модель
            {
                id = null,
                ProfileName = null,
                ResourceObjectId = null,
                ProfileObjects = null,
                request_params = null
            };

            Assert.True(модель1.Валидна().Нет(), модель1.получитьИсключение?.Message);
            Assert.IsNotNull(модель1.получитьИсключение?.Message);

            {
                var модель = new ДанныеИзФормы_СозданиеПрофиляДоступа_модель
                {
                    id = null,
                    ProfileName = "",
                    ResourceObjectId = 0,
                    ProfileObjects = new ProfileObjects?[]{},
                    request_params = new RequestParams()
                };

                Assert.True(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
                
                TestHelper.PrintTestContext(модель.ПолучитьРезультатыВалидации().ToList());
            }
        }

        [Test]
        public void ВалиднаяМодель()
        {
            Assert.Fail();
        }
    }
}