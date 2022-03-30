using System;
using System.Collections.Generic;
using static QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.InitModule;

namespace QWERTY.Shared2.Tests.Обслуживание_Тестов
{
    public static class НеВалидные
    {
        internal static readonly DateTime неВалиднаяДата = new DateTime(1999, 12, 31, 23, 59, 59);
        
        internal static readonly string?[] неВалидныеСтроки_Nullable = { null, "" };
        internal static int?[] неВалидныеЦелые_Nullable = { null, -1, 0, int.MinValue };
        internal static readonly DateTime?[] неВалидныеДаты_Nullable = 
        {
            DateTime.MinValue,
            DateTime.MaxValue,
            неВалиднаяДата,
            null
        };

        internal static readonly byte?[]?[] неВалидныеМассивыСоДанными_Nullable =
        {
            null,
            new byte?[0]{},
            new byte?[1]{null},
            new byte?[2]{2, null},
            new byte?[2]{null, 2},
        };
        
        
        internal static readonly int[] неВалидныеЦелые_NotNullable = { -1, 0, int.MinValue };
        internal static readonly DateTime[] неВалидныеДаты_NotNullable =
        {
            DateTime.MinValue,
            DateTime.MaxValue,
            неВалиднаяДата
        };
        internal static readonly byte?[]?[] неВалидныеМассивыСоДанными_NotNullable =
        {
            new byte?[0]{},
            new byte?[1]{null},
            new byte?[2]{2, null},
            new byte?[2]{null, 2},
        };
    }

    public static class Валидные
    {
        internal static readonly int[] ВалидныеЦелые_NotNullable = { 1, int.MaxValue };
    }
}