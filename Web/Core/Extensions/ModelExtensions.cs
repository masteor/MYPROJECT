using System;

namespace QWERTY.Web.Core.Extensions
{
    public static class ModelExtensions
    {

        /*
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
        public static bool IsNotNull<TSource>(this TSource ts) => !ts.IsNull();
        public static bool IsNullOrZero(this int? i) => i == null || i == 0;
        public static bool IsNullOrZero(this int i) => i == 0;
        public static bool NotIsNullOrZero(this int? i) => !IsNullOrZero(i);
        public static bool NotIsNullOrZero(this int i) => !IsNullOrZero(i);

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
        public static string IfNullStringEmpty<TSource>(this TSource t) => IfNull(t, string.Empty);
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
            && armUser.ЗаявкаПрекращенияДопуска?.ДатаЗавершения?.Ticks >= date.Ticks;#1#
            */

        /// <summary>
        ///
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? ЗапарситьДату(this string? dateTime) =>
            dateTime == null ? null : 
                DateTime.TryParse(s: dateTime, result: out var dT) == false 
                    ? (DateTime?) null 
                        // добиваем дату до конца суток
                    : dT.Date.Add(value: new TimeSpan(days: 0, hours: 23, minutes: 59, seconds: 59)); 
    }
}
