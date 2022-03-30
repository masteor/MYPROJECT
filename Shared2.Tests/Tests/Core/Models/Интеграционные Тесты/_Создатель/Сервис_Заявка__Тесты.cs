using QWERTY.Shared.Models;
using QWERTY.Shared.Models._Создатель;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Интеграционные_Тесты._Создатель
{
    [TestFixture]
    public class Сервис_Заявка : Init
    {
        [Test]
        public void Создаем_Заявку_Валидные_данные_Не_бросает_исключение()
        {
            var данныеИзФормы = new ДанныеИзФормы
            {
                id = null,
                request_params = new RequestParams("kirillovanm")
            };
            
            var создатель = new Создатель<ДанныеИзФормы>(
                CommonService,
                Log,
                данныеИзФормы.request_params.sender_login,
                данныеИзФормы,
                null
            );

        }
    }
}