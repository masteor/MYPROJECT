using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Extensions;
using QWERTY.Shared.Models;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;
using static QWERTY.Shared2.Tests.Обслуживание_Тестов.TestHelper;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.ВалидацияМоделей
{
    [TestFixture]
    public class Валидация_RequestParams__Тесты : InitModule
    {

        [TestCaseSource(nameof(OtherInvalidCases))]
        public void НеВалиднаяМодельСоИзмененнымиСвойствами(RequestParams модель)
        {
            TestHelper.PrintTestContext(модель);
            Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
            Assert.IsNotNull(модель.получитьИсключение?.Message);
        }

        [Test]
        public void ПроверкаГенерацииМоделей()
        {
            foreach (var @case in OtherInvalidCases()) 
                НапечататьИсходнуюМодельВоКноТестов(@case);
        }

        private static IEnumerable<RequestParams> OtherInvalidCases()
        {
            // var f = ПолучитьФикстуру<RequestParams>();
            var фикстуруRequestParams = ПолучитьФикстуру_RequestParams();
            var sd = Рефлектор
                    .ПолучитьМоделиСИзмененнымСвойством<RequestParams>(фикстуруRequestParams);

            return sd;
        }


        [TestCaseSource(nameof(InvalidCases))]
        public void НеВалиднаяМодель(RequestParams модель)
        {
            Assert.IsTrue(модель.Валидна().Нет(), модель.получитьИсключение?.Message);
            Assert.IsNotNull(модель.получитьИсключение?.Message);
        }

        private static IEnumerable<RequestParams> InvalidCases()
        {
            yield return new RequestParams();

            yield return new RequestParams
            {
                create_date_time = null,
                end_date_time = null,
                sender_login = string.Empty,
                recipient_login = null,
                request_state_id = null,
                doc = null,
                reg_number = null,
                parent = null
            };

            yield return new RequestParams
            {
                create_date_time = null,
                end_date_time = null,
                sender_login = null,
                recipient_login = null,
                request_state_id = null,
                doc = null,
                reg_number = null,
                parent = null
            };

            yield return new RequestParams
            {
                create_date_time = null,
                end_date_time = null,
                sender_login = "1",
                recipient_login = null,
                request_state_id = null,
                doc = null,
                reg_number = null,
                parent = null
            };
        }

        [Test]
        public void ВалиднаяМодель()
        {
            {
                var модель = new RequestParams
                {
                    create_date_time = null,
                    end_date_time = null,
                    sender_login = "12",
                    recipient_login = null,
                    request_state_id = null,
                    doc = null,
                    reg_number = null,
                    parent = null
                };

                Assert.IsTrue(модель.Валидна(), модель.получитьИсключение?.Message);
                Assert.IsNull(модель.получитьИсключение?.Message);
            }
        }
    }
}