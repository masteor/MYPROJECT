using QWERTY.Shared.Extensions;
using QWERTY.Shared.Models;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.ВалидацияМоделей
{
    [TestFixture]
    public class Валидация_ДанныеИзФормы__Тесты : IМоделиТесты
    {
        [Test]
        public void НеВалиднаяМодель()
        {
            {
                var модель = new ДанныеИзФормы
                {
                    id = null,
                    request_params = null
                };

                Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }

            {
                var модель = new ДанныеИзФормы
                {
                    id = null,
                    request_params = new RequestParams()
                };

                Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
                Assert.IsNotNull(модель.получитьИсключение?.Message);
            }
        }
        
        [Test]
        public void ВалиднаяМодель()
        {
            {
                var модель = new ДанныеИзФормы
                {
                    id = null,
                    request_params = new RequestParams("kirillovanm")
                };

                Assert.IsTrue(модель.Валидна(), модель.получитьИсключение?.Message);
                Assert.IsNull(модель.получитьИсключение?.Message);
            }
            
            {
                var модель = new ДанныеИзФормы
                {
                    id = null,
                    request_params = new RequestParams
                    {
                        create_date_time = null,
                        end_date_time = null,
                        sender_login = "kirillovanm",
                        recipient_login = null,
                        request_state_id = null,
                        doc = null,
                        reg_number = null,
                        parent = null
                    }
                };

                Assert.IsTrue(модель.Валидна(), модель.получитьИсключение?.Message);
                Assert.IsNull(модель.получитьИсключение?.Message);
            }
        }
    }
}