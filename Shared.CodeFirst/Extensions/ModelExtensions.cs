using System;
using System.Collections.Generic;

namespace QWERTY.Shared.Extensions
{
    
    public static class ModelExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ЧекнутьДату(this DateTime dateTime) => 
            dateTime == default ? "<отсутствует>" : Convert.ToString(dateTime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ЧекнутьДату(this DateTime? dateTime) => 
            dateTime == null ? "<отсутствует>" : Convert.ToString(dateTime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Нет(this bool b) => !b;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static bool Никого<TSource>(this List<TSource> list) => list.IsNull() || list?.Count < 1;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static bool КтотоЕсть<TSource>(this List<TSource> list) => !Никого(list);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ts"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static bool IsNull<TSource>(this TSource ts) => ts == null;

        public static bool IsNull<T>(this IEnumerable<T> enumerable) => enumerable == null;
        
        public static bool IsNotNull<TSource>(this TSource ts) => !ts.IsNull();
        public static bool IsNullZeroOrLess(this int? i) => i == null || i <= 0;
        public static bool IsNullZeroOrLess(this int i) => i <= 0;
        public static bool IsNotNullZeroOrLess(this int? i) => !IsNullZeroOrLess(i); 
        public static bool IsNotNullZeroOrLess(this int i) => !IsNullZeroOrLess(i);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="s"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static string IfNull<TSource>(this TSource t, string s) => t == null ? s : Convert.ToString(t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static string IfNullReturnStringEmpty<TSource>(this TSource t) => IfNull(t, string.Empty);


        public static bool IsNullOrEmpty<T>(this T[] t) => t == null || t.Length < 1;
        public static bool IsNotNullOrEmpty<T>(this T[] t) => !IsNullOrEmpty(t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ThrowIfNull<TSource>(this TSource t)
        {
            if (t.IsNull()) throw new Exception($"данный объект {nameof(t)} не должен быть null");
            return Convert.ToString(t);
        }
        /// <summary>
        /// получаем ограниченный диапазон значений списка
        /// </summary>
        /// <param name="list"></param>
        /// <param name="to">-1 или нет значения - получить все</param>
        /// <typeparam name="TS"></typeparam>
        /// <returns></returns>
        public static List<TS> ПолучитьДиапазон<TS>(this List<TS> list, int to = -1) => 
            list.Count < to || to == -1 ? list : list.GetRange(0, to);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="armUser"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        /*public static bool СоответствующиеДате(this ARM_USER armUser, DateTime date) =>
            armUser.ЗаявкаРазрешенияДопуска?.ДатаЗавершения?.Ticks <= date.Ticks
            && armUser.ЗаявкаПрекращенияДопуска?.ДатаЗавершения?.Ticks >= date.Ticks;*/

        /*/// <summary>
        /// 
        /// </summary>
        /// <param name="date_time"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DateTime? ЗапарситьДату(this Query_model model) => model.date_time != null ? DateTime.Parse(model.date_time) : (DateTime?) null;*/
        


        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="строка"></param>
        /// <returns></returns>
        public static string ОчиститьОтПробеловНачалоКонец(this string строка) => 
            string.IsNullOrEmpty(строка) ? строка : строка.Trim(new[] {' '});
    }
}