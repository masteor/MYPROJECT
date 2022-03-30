using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using QWERTY.Shared.Models.Сущности;
using QWERTY.Shared2.Tests.Tests.Core;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Обслуживание_Тестов
{
    public static class TestHelper
    {
        private const string перваяИлиПоследняяСтрокаКускаТеста = "========================";
        private const string перваяИлиПоследняяСтрокаМоделиВоРамке = "------------------";
        private const string исходнаяМодельТитульник = "Исходная модель: ";
        private const string измененнаяМодельТитульник = "Измененная модель: ";
        
        public static string Print(this IEnumerable<string>? enumerable, string разделитель)
        {
            if (enumerable == null) return "<пустой список>";
            return enumerable.Aggregate("", (сумма, текущийЭлемент) =>
                сумма + текущийЭлемент switch
                      {
                          null => "<null>",
                          "" => "<empty>",
                          _ => текущийЭлемент
                      }
                      + разделитель
            ).Replace(' ', '˽');
        }

        public static string Print(int? s) => s != null ? s.Value.ToString() : "null";
        
        public static string Print(object? s) 
            =>
                s != null 
                    ? (s.ToString().Length == 0 
                        ? "<пусто>" 
                        : s.ToString()) 
                    : "null";

        
        public static void Print(ДанныеИзФормы_СозданияЛогина_модель модель)
        {
            Console.WriteLine($@"email: {Print(модель.email)}");
            Console.WriteLine($@"employee_id: {Print(модель.id_user)}");
            Console.WriteLine($@"fragment_id: {Print(модель.id_domen)}");
            Console.WriteLine($@"login_name: {Print(модель.login_name)}");
        }

        internal static void PrintTestContext<T>((T, string) модель) where T : class
        {
            foreach (var поле in модель.Item1.получитьЗначенияПолейДляПечати()) 
                TestContext.Out.WriteLine(Print(поле));
        }
        
        internal static void PrintTestContext<T>(T? модель) where T : class
        {
            if (модель == null) 
                TestContext.Out.WriteLine("модель = null");
            else
                foreach (var поле in модель.получитьЗначенияПолейДляПечати())
                    TestContext.Out.WriteLine(Print(поле));
        }

        internal static void PrintTestContext(List<ValidationResult> results)
        {
            foreach (var поле in results) 
                TestContext.Out.WriteLine(Print(поле));
        }

        internal static void PrintTestContext(string? s) => TestContext.Out.WriteLine(Print(s));

        private static void НапечататьМодельВоКноТестовСоЗаголовком<T>(string title, T модель) where T : class
        {
            PrintTestContext(title);
            НапечататьМодельВоРамке(модель);
        }

        internal static void НапечататьИсходнуюМодельВоКноТестов<T>(T модель) where T : class 
            => 
                НапечататьМодельВоКноТестовСоЗаголовком(исходнаяМодельТитульник, модель);

        internal static void НапечататьИзмененнуюМодельВоКноТестов<T>(T модель) where T : class 
            => 
                НапечататьМодельВоКноТестовСоЗаголовком(измененнаяМодельТитульник, модель);

        internal static void НапечататьМодельВоРамке<T>(T? модель) where T : class
        {
            PrintTestContext(перваяИлиПоследняяСтрокаМоделиВоРамке);
            PrintTestContext(модель);
            PrintTestContext($"{перваяИлиПоследняяСтрокаМоделиВоРамке}\n");    
        }
        
        internal static void НапечататьЗавершающуюСтрокуДляКускаТеста() 
            => 
                PrintTestContext($"{перваяИлиПоследняяСтрокаКускаТеста}\n");
        
        internal static void НапечататьТитульникДляКускаТеста(string title)
        {
            PrintTestContext(title);
            PrintTestContext($"{перваяИлиПоследняяСтрокаКускаТеста}");
        }

        private static IEnumerable<string> получитьЗначенияПолейДляПечати<T>(this T? m) where T : class
        {
            if (m == null) yield break;

            Type type = m.GetType();
            foreach (var p in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                yield return $"{Print(p.Name)}: {Print(p.GetValue(m))}";    
            }
        }
    }
}
