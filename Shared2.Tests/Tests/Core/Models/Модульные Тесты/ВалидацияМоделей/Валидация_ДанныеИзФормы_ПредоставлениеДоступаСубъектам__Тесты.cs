using QWERTY.Shared.Extensions;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models.Заявки.Заявка_на_предоставление_доступа_к_защищаемым_ресурсам;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.ВалидацияМоделей
{
    [TestFixture]
    public class Валидация_ДанныеИзФормы_ПредоставлениеДоступаСубъектам__Тесты : InitModule, IМоделиТесты
    {
        [Test]
        public void НеВалиднаяМодель()
        {
            {
                var модель = new ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель
                {
                    id = null,
                    ProfileId = null,
                    UserIds = null,
                    OrgIds = null,
                    request_params = null
                };

                Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }
            
            {
                var модель = new ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель
                {
                    id = null,
                    ProfileId = 1,
                    UserIds = new int?[]{},
                    OrgIds = new int?[]{},
                    request_params = new RequestParams("jksdfh")
                };

                Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }
            
            {
                var модель = new ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель
                {
                    id = null,
                    ProfileId = 1,
                    UserIds = new int?[]{new int()},
                    OrgIds = new int?[]{new int()},
                    request_params = new RequestParams("jksdfh")
                };

                Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }
            
            {
                var модель = new ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель
                {
                    id = null,
                    ProfileId = 1,
                    UserIds = new int?[]{null},
                    OrgIds = new int?[]{null},
                    request_params = new RequestParams("jksdfh")
                };

                Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }
            
            {
                var модель = new ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель
                {
                    id = null,
                    ProfileId = 1,
                    UserIds = new int?[]{0},
                    OrgIds = new int?[]{0},
                    request_params = new RequestParams("jksdfh")
                };

                Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }
        }

        [Test]
        public void ВалиднаяМодель()
        {
            {
                var модель = new ДанныеИзФормы_ПредоставлениеДоступаСубъектам_модель
                {
                    id = null,
                    ProfileId = 1,
                    UserIds = new int?[]{1},
                    OrgIds = new int?[]{1},
                    request_params = new RequestParams("jksdfh")
                };

                Assert.IsTrue(модель.Валидна(), модель.получитьИсключение?.Message);
                Assert.IsNull(модель.получитьИсключение?.Message);
            }
        }
    }
}