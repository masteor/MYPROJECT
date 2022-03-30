using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models;
using QWERTY.Shared.Models._Создатель;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NSubstitute;
using static QWERTY.Shared2.Tests.Обслуживание_Тестов.НеВалидные;
using static QWERTY.Shared2.Tests.Обслуживание_Тестов.Валидные;
using static QWERTY.Shared2.Tests.Обслуживание_Тестов.TestHelper;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты._Создатель.Сервис_Заявка__Тесты
{
    [TestFixture]
    public class Сервис_Заявка__ОткатитьВсеСозданныеЗаявки__Тесты : InitModule
    {
        private int идОткатываемойЗаявки;
        private IEnumerable<VIEW_REPORT_ALL_REQUESTS> подчиненныеЗаявки;
        private IEnumerable<VIEW_REPORT_ALL_REQUESTS> подчиненныхЗаявокНет;
        private REQUEST? родительскаяЗаявка;
        private List<REQUEST> другиеЗаявки;
        private int идТекущегоСтатуса = (int) ИдСтатусаЗаявки.Зарегистрирована;

        public Сервис_Заявка__ОткатитьВсеСозданныеЗаявки__Тесты()
        {
            идОткатываемойЗаявки = ПолучитьФикстуру<int>();
            родительскаяЗаявка = new REQUEST
            {
                id = идОткатываемойЗаявки,
                id_request_state = идТекущегоСтатуса,
            };

            другиеЗаявки = СоздатьНовыйСписок_REQUEST(
                new int[]{1,2,3},
                родительскаяЗаявка.id_request_state
            );
            подчиненныеЗаявки = ПодчиненныеЗаявкиЕсть(другиеЗаявки, идОткатываемойЗаявки);
            подчиненныхЗаявокНет = ПодчиненныхЗаявокНет(другиеЗаявки);
        }

        private IEnumerable<VIEW_REPORT_ALL_REQUESTS> ПодчиненныеЗаявкиЕсть(IEnumerable<REQUEST> requests, int? идРодительскойЗаявки) 
            =>
            (requests ?? throw new ArgumentNullException(nameof(requests)))
            .Select((r, i) => new VIEW_REPORT_ALL_REQUESTS
            {
                id_request = r.id,
                parent = идРодительскойЗаявки
            });

        private IEnumerable<VIEW_REPORT_ALL_REQUESTS> ПодчиненныхЗаявокНет(IEnumerable<REQUEST> requests)
            =>
                ПодчиненныеЗаявкиЕсть(requests, null);
        
        private void ВключитьНастройку_ПолучитьЗаявкиИзПредставления_возвращаетПодчиненныеЗаявкиЕсть()
        {
            _commonService.ПолучитьЗаявкиИзПредставления
                    (Arg.Any<Expression<Func<VIEW_REPORT_ALL_REQUESTS, bool>>>())
                .Returns(подчиненныеЗаявки);
        }
        
        private void ВключитьНастройку_ПолучитьЗаявкиИзПредставления_возвращаетПодчиненныхЗаявокНет()
        {
            _commonService.ПолучитьЗаявкиИзПредставления
                    (Arg.Any<Expression<Func<VIEW_REPORT_ALL_REQUESTS, bool>>>())
                .Returns(подчиненныхЗаявокНет);
        }
        
        [Test]
        public void ПроверкаПравильностиИнициализации()
        {
            {
                ВключитьНастройку_ПолучитьЗаявкиИзПредставления_возвращаетПодчиненныеЗаявкиЕсть();

                var enumerable = _commonService
                    .ПолучитьЗаявкиИзПредставления(r => true).ToList();

                Assert.True(enumerable.Count > 0);
                Assert.True(enumerable.All(r => r.parent == идОткатываемойЗаявки));
            }
            
            {
                ВключитьНастройку_ПолучитьЗаявкиИзПредставления_возвращаетПодчиненныхЗаявокНет();

                var enumerable = _commonService
                    .ПолучитьЗаявкиИзПредставления(r => true).ToList();

                Assert.True(enumerable.Count > 0);
                Assert.True(enumerable.All(r => r.parent == null));
            }
        }

        [TestCaseSource(typeof(НеВалидные), nameof(неВалидныеЦелые_Nullable))]
        public void ОткатитьВсеСозданныеЗаявки_параметр_НеВалиден__ВозвращаетОшибку(int? @case)
        {
            var создатель = 
                new Создатель<ДанныеИзФормы>(_commonService,log);
            
            Assert.DoesNotThrow(() => создатель?.ОткатитьВсеСозданныеЗаявки(@case));
            Assert.True(создатель?.Ошибка?.GetType() == typeof(ArgumentOutOfRangeException));
        }

        
        // [TestCaseSource(typeof(Валидные), nameof(ВалидныеЦелые_NotNullable))]
        [Test]
        public void ОткатитьВсеСозданныеЗаявки_параметр_Валиден__ПодчиненныхЗаявокНет_ОшибокНет()
        {
            throw new NotImplementedException();
            ВключитьНастройку_ПолучитьЗаявкиИзПредставления_возвращаетПодчиненныхЗаявокНет();
            
            var создатель = 
                new Создатель<ДанныеИзФормы>(_commonService,log);
            
            Assert.DoesNotThrow(() => создатель?
                .ОткатитьВсеСозданныеЗаявки(ПолучитьФикстуру<int>()));
            
            Assert.False(создатель.ПроизошлаОшибка, создатель.Ошибка?.Message);
        }
        
        [TestCaseSource(typeof(Валидные), nameof(Валидные.ВалидныеЦелые_NotNullable))]
        public void ОткатитьВсеСозданныеЗаявки_параметр_Валиден__ПодчиненныеЗаявкиЕсть_ОшибокНет(int @case)
        {
            throw new NotImplementedException(); 
                
            ВключитьНастройку_ПолучитьЗаявкиИзПредставления_возвращаетПодчиненныеЗаявкиЕсть();
            _commonService
                .ПолучитьЗаявкуПоИд(Arg.Any<int>())
                .Returns(ПолучитьФикстуру<REQUEST>());
            
            var создатель = 
                new Создатель<ДанныеИзФормы>(_commonService,log);
            
            Assert.DoesNotThrow(() => создатель?.ОткатитьВсеСозданныеЗаявки(@case));
            Assert.False(создатель.ПроизошлаОшибка, создатель.Ошибка?.Message);
        }
    }
}