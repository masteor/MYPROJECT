using System;
using System.Linq;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models._Создатель;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты._Создатель.Сервис_Заявка__Тесты
{
    [TestFixture]
    public class Сервис_Заявка__СоздатьЗаявкуПоИмениТипа__Тесты : InitModule
    {
        [SetUp]
        public void ИнициализацияЗаглушек()
        {
        } 
        
        [Test]
        public void Создаем_Заявку_Валидные_данные_Не_бросает_исключение()
        {
            var данныеИзФормы = ПолучитьВалиднуюМодель_ДанныеИзФормы();
            {
                Assert.True(данныеИзФормы.Валидна());
            }

            Создатель<ДанныеИзФормы>? создатель = null;
            {
                Assert.DoesNotThrow(() =>
                    создатель = ПолучитьВалиднуюМодель_Создатель_ДанныеИзФормы_N5(данныеИзФормы, null));
                Assert.IsNotNull(создатель);
            }

            REQUEST? заявка = null;
            {
                Assert.DoesNotThrow(() => заявка = создатель?.СоздатьЗаявкуПоИмениТипа(
                    типыЗаявок.FirstOrDefault()?.code ?? throw new InvalidOperationException("code is null"),
                    данныеИзФормы.request_params!,
                    РодительскаяЗаявка
                ), создатель?.Ошибка?.Message);

                Assert.NotNull(заявка);
                Assert.IsTrue(заявка?.id > 0);
                Assert.IsNull(создатель?.Ошибка);
            }
        }
    }
}