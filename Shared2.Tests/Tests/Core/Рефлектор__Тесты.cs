using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты;
using QWERTY.Shared2.Tests.Обслуживание_Тестов;
using NUnit.Framework;
using static QWERTY.Shared2.Tests.Обслуживание_Тестов.TestHelper;
using static QWERTY.Shared2.Tests.Обслуживание_Тестов.Рефлектор;

namespace QWERTY.Shared2.Tests.Tests.Core
{
    [TestFixture]
    public class Рефлектор__Тесты : InitModule
    {
        [Test]
        public void ПолучитьНеВалидныеЗначенияОтТипаСвойства__Тест()
        {
            {
                var значения= НеВалидные.неВалидныеСтроки_Nullable;
                var enumerable = ((IEnumerable<string>) ПолучитьНеВалидныеЗначенияОтТипаСвойства(typeof(string))).ToArray();
                
                Assert.AreEqual(значения.Length, enumerable.Length);
                
                for (var i = 0; i < значения.Length - 1; i++)
                    Assert.AreEqual(enumerable[i], значения[i]);
            }
            
            {
                var значения = НеВалидные.неВалидныеЦелые_NotNullable;
                var enumerable = ((IEnumerable<int>) ПолучитьНеВалидныеЗначенияОтТипаСвойства(typeof(int))).ToArray();
                
                Assert.AreEqual(значения.Length, enumerable.Length);
                
                for (var i = 0; i < значения.Length - 1; i++)
                    Assert.AreEqual(enumerable[i], значения[i]);
            }
            
            {
                var значения = НеВалидные.неВалидныеЦелые_Nullable;
                var enumerable = ((IEnumerable<int?>) ПолучитьНеВалидныеЗначенияОтТипаСвойства(typeof(int?))).ToArray();
                
                Assert.AreEqual(значения.Length, enumerable.Length);
                
                for (var i = 0; i < значения.Length - 1; i++)
                    Assert.AreEqual(enumerable[i], значения[i]);
            }
        }

        [Test]
        public void ПолучитьМоделиСИзмененнымСвойством__Тест()
        {
            {
                НапечататьТитульникДляКускаТеста(nameof(НеВалидные.неВалидныеЦелые_NotNullable));
                неВалидныеЦелые_NotNullable();
                НапечататьЗавершающуюСтрокуДляКускаТеста();

                void неВалидныеЦелые_NotNullable()
                {
                    var неВалидныеЦелыеNotNullable = НеВалидные.неВалидныеЦелые_NotNullable;
                    var модель = new МодельЦелое();
                    НапечататьИсходнуюМодельВоКноТестов(модель);

                    var моделиСИзмененнымСвойством = ПолучитьМоделиСИзмененнымСвойством(модель);

                    Assert.NotNull(моделиСИзмененнымСвойством);
                    Assert.AreNotEqual(моделиСИзмененнымСвойством, 0);
                    Assert.AreEqual(моделиСИзмененнымСвойством.Count(), неВалидныеЦелыеNotNullable.Length);

                    var c = 0;
                    foreach (var модельЦелое in моделиСИзмененнымСвойством)
                    {
                        НапечататьИзмененнуюМодельВоКноТестов(модельЦелое);
                        Assert.AreEqual(модельЦелое.a, неВалидныеЦелыеNotNullable[c]);
                        c++;
                    }
                }
            }

            {
                НапечататьТитульникДляКускаТеста(nameof(НеВалидные.неВалидныеЦелые_Nullable));
                неВалидныеЦелые_NotNullable();
                НапечататьЗавершающуюСтрокуДляКускаТеста();
                
                void неВалидныеЦелые_NotNullable()
                {
                    var неВалидныеЦелыеNullable = НеВалидные.неВалидныеЦелые_Nullable;
                    var модель = new МодельЦелое_Nullable();
                    НапечататьИсходнуюМодельВоКноТестов(модель);

                    var моделиСИзмененнымСвойством = ПолучитьМоделиСИзмененнымСвойством(модель);
                    Assert.NotNull(моделиСИзмененнымСвойством);
                    Assert.AreNotEqual(моделиСИзмененнымСвойством, 0);
                    Assert.AreEqual(моделиСИзмененнымСвойством.Count(), неВалидныеЦелыеNullable.Length);

                    var c = 0;
                    foreach (var модельЦелоеNullable in моделиСИзмененнымСвойством)
                    {
                        НапечататьИзмененнуюМодельВоКноТестов(модельЦелоеNullable);
                        Assert.AreEqual(модельЦелоеNullable.a, неВалидныеЦелыеNullable[c]);
                        c++;
                    }
                }
            }
            
            
            {
                НапечататьТитульникДляКускаТеста(nameof(НеВалидные.неВалидныеДаты_NotNullable));
                неВалидныеЦелые_NotNullable();
                НапечататьЗавершающуюСтрокуДляКускаТеста();

                void неВалидныеЦелые_NotNullable()
                {
                    var неВалидныеДатыNotNullable = НеВалидные.неВалидныеДаты_NotNullable;
                    var модель = new МодельДата();
                    НапечататьИсходнуюМодельВоКноТестов(модель);

                    var моделиСИзмененнымСвойством = ПолучитьМоделиСИзмененнымСвойством(модель);
                    Assert.NotNull(моделиСИзмененнымСвойством);
                    Assert.AreNotEqual(моделиСИзмененнымСвойством, 0);
                    Assert.AreEqual(моделиСИзмененнымСвойством.Count(), неВалидныеДатыNotNullable.Length);

                    var c = 0;
                    foreach (var модельДата in моделиСИзмененнымСвойством)
                    {
                        НапечататьИзмененнуюМодельВоКноТестов(модельДата);
                        Assert.AreEqual(модельДата.d, неВалидныеДатыNotNullable[c]);
                        c++;
                    }
                }
            }
            
            {
                НапечататьТитульникДляКускаТеста(nameof(НеВалидные.неВалидныеДаты_Nullable));
                неВалидныеДаты_Nullable();
                НапечататьЗавершающуюСтрокуДляКускаТеста();

                void неВалидныеДаты_Nullable()
                {
                    var неВалидныеДатыNullable = НеВалидные.неВалидныеДаты_Nullable;
                    var модель = new МодельДата_Nullable();
                    НапечататьИсходнуюМодельВоКноТестов(модель);

                    var моделиСИзмененнымСвойством = ПолучитьМоделиСИзмененнымСвойством(модель);
                    Assert.NotNull(моделиСИзмененнымСвойством);
                    Assert.AreNotEqual(моделиСИзмененнымСвойством, 0);
                    Assert.AreEqual(моделиСИзмененнымСвойством.Count(), неВалидныеДатыNullable.Length);

                    var c = 0;
                    foreach (var модельДатаNullable in моделиСИзмененнымСвойством)
                    {
                        НапечататьИзмененнуюМодельВоКноТестов(модельДатаNullable);
                        Assert.AreEqual(модельДатаNullable.d, неВалидныеДатыNullable[c]);
                        c++;
                    }
                }
            }
            
            {
                НапечататьТитульникДляКускаТеста(nameof(НеВалидные.неВалидныеСтроки_Nullable));
                неВалидныеСтроки_Nullable();
                НапечататьЗавершающуюСтрокуДляКускаТеста();

                void неВалидныеСтроки_Nullable()
                {
                    var неВалидныеСтрокиNullable = НеВалидные.неВалидныеСтроки_Nullable;
                    var модель = new МодельСтрока();
                    НапечататьИсходнуюМодельВоКноТестов(модель);

                    var моделиСИзмененнымСвойством = ПолучитьМоделиСИзмененнымСвойством(модель);
                    Assert.NotNull(моделиСИзмененнымСвойством);
                    Assert.AreNotEqual(моделиСИзмененнымСвойством, 0);
                    Assert.AreEqual(моделиСИзмененнымСвойством.Count(), неВалидныеСтрокиNullable.Length);

                    var c = 0;
                    foreach (var модельСтрока in моделиСИзмененнымСвойством)
                    {
                        НапечататьИзмененнуюМодельВоКноТестов(модельСтрока);
                        Assert.AreEqual(модельСтрока.s, неВалидныеСтрокиNullable[c]);
                        c++;
                    }
                }
            }
            
            {
                НапечататьТитульникДляКускаТеста("Меняем свойства в модели");
                NewFunction();
                НапечататьЗавершающуюСтрокуДляКускаТеста();
                
                void NewFunction()
                {
                    var модель = ПолучитьФикстуру<МодельОбщая>(); 
                    НапечататьИсходнуюМодельВоКноТестов(модель);

                    var колВоНеВалидных =
                        НеВалидные.неВалидныеДаты_NotNullable.Length +
                        НеВалидные.неВалидныеДаты_Nullable.Length +
                        НеВалидные.неВалидныеСтроки_Nullable.Length +
                        НеВалидные.неВалидныеЦелые_NotNullable.Length +
                        НеВалидные.неВалидныеЦелые_Nullable.Length;

                    var моделиСИзмененнымСвойством = ПолучитьМоделиСИзмененнымСвойством(модель);
                    Assert.NotNull(моделиСИзмененнымСвойством);
                    Assert.AreNotEqual(моделиСИзмененнымСвойством, 0);
                    Assert.AreEqual(моделиСИзмененнымСвойством.Count(), колВоНеВалидных);

                    foreach (var модель1 in моделиСИзмененнымСвойством)
                        НапечататьИзмененнуюМодельВоКноТестов(модель1);
                }
            }
        }

        

        private class МодельЦелое
        {
            public int a { get; set; }
        }
        
        private class МодельЦелое_Nullable
        {
            public int? a { get; set; }
        }
        
        private class МодельДата
        {
            public DateTime d { get; set; }
        }
        
        private class МодельДата_Nullable
        {
            public DateTime? d { get; set; }
        }
        
        private class МодельСтрока
        {
            public string s { get; set; }
        }
        
        private class МодельОбщая
        {
            public int i1 { get; set; }
            public string s { get; set; }
            public int? i2 { get; set; }
            public DateTime d1 { get; set; }
            public DateTime? d2 { get; set; }
        }
    }
}