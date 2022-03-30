using System;
using System.Collections.Generic;
using AutoFixture;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models._Создатель;
using NSubstitute;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты._Создатель.Сервис_Заявка__Тесты
{
    [TestFixture]
    public class Сервис_Заявка__СменитьСтатусЗаявки__Тесты : InitModule
    {

        [TestCase(null)]
        public void СменитьСтатусЗаявки__параметр_НеВалиден__ВозвращаетОшибку(REQUEST? @case)
        {
            var создатель = 
                new Создатель<ДанныеИзФормы>(_commonService,log);

            Assert.Throws<ArgumentNullException>(() =>
                создатель.СменитьСтатусЗаявки(@case, БуквенныеКодыСтатусовЗаявок.ROLLBACKED));
        }
        
        /// <summary>
        /// Ожидания - ид_текущего_статуса_заявки меняется на нужный, дата_завершения - меняется
        /// </summary>
        /// <param name="case"></param>
        [TestCaseSource(nameof(Cases))]
        public void СменитьСтатусЗаявки__передаёмСтатусДляЗамены__статусМеняетсяУспешно(REQUEST @case)
        {
            var создатель = 
                new Создатель<ДанныеИзФормы>(_commonService,log);

            var возвращаемыйСтатус = ПолучитьФикстуру<REQUEST_STATE>();
            _commonService
                .ПолучитьСтатусЗаявкиПоКоду(Arg.Any<string>())
                .Returns(возвращаемыйСтатус);

            REQUEST? сменитьСтатусЗаявки = null;
            
            Assert.DoesNotThrow(() => сменитьСтатусЗаявки = 
                создатель.СменитьСтатусЗаявки
                    (new REQUEST(@case),
                    БуквенныеКодыСтатусовЗаявок.ROLLBACKED));
            
            Assert.IsNotNull(сменитьСтатусЗаявки);
            Assert.AreEqual(возвращаемыйСтатус.id, сменитьСтатусЗаявки?.id_request_state);
            Assert.AreNotEqual(@case.date_2,                                                                                      сменитьСтатусЗаявки?.date_2);
        }

        
        private static IEnumerable<REQUEST> Cases()
        {
            yield return new REQUEST();
            yield return new REQUEST
            {
                id_request_state = ПолучитьФикстуру<int>(),
            };
            yield return new REQUEST
            {
                id_request_state = ПолучитьФикстуру<int>(),
                date_2 = ПолучитьФикстуру<DateTime>()
            };
            // yield return СоздатьНовыйСписок_REQUEST(new[] {3, 2, 1}, (int) ИдСтатусаЗаявки.Зарегистрирована);
        }
    }
}