using System;
using System.Linq;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_защищаемого_ресурса;
using QWERTY.Shared.Models.Заявки.Заявка_на_создание_профиля_доступа_на_ресурс;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.ВалидацияМоделей
{
    [TestFixture]
    public class Валидация_ДанныеИзФормы_СозданиеПрофиляДоступаНаЗащищаемыйРесурс_модель__Тесты : IМоделиТесты
    {
        [Test]
        public void НеВалиднаяМодель()
        {
            {
                var модель = new ДанныеИзФормы_СозданиеПрофиляДоступа_модель
                {
                    id = null,
                    ProfileName = String.Empty,
                    ResourceObjectId = 1,
                    ProfileObjects = new ProfileObject?[]
                    {
                        new ProfileObject()
                    },
                    request_params = null
                };

                Assert.IsFalse(модель.Валидна(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
                
                TestHelper.PrintTestContext(модель.ПолучитьРезультатыВалидации().ToList());
            }
        }

        [Test]
        public void ВалиднаяМодель()
        {
            {
                var модель = new ДанныеИзФормы_СозданиеПрофиляДоступа_модель
                {
                    id = null,
                    ProfileName = "12",
                    ResourceObjectId = 1,
                    ProfileObjects = new ProfileObject?[]
                    {
                        new ProfileObject()
                    },
                    request_params = new RequestParams("qwertghyjkl")
                };

                Assert.IsTrue(модель.Валидна(), модель.получитьИсключение?.Message);
                Assert.IsNull(модель.получитьИсключение?.Message);
                
                TestHelper.PrintTestContext(модель.ПолучитьРезультатыВалидации().ToList());
            }
        }
    }
}