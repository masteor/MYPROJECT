using System;

namespace QWERTY.Shared.Helpers
{
    public static class DateTimeHelper
    {
        internal static string? DateToUtc(this DateTime? dateTime) 
            => 
                dateTime == null ? null : $"{dateTime:yyyy-MM-ddTHH:mm:ss.FFZ}";
    }
}