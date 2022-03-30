using System;

namespace QWERTY.Shared.Db.Validation
{
    public static class ValidateExtensions
    {
        public static string HasMaxLength(this string str, int length)
        {
            if (length < 0) throw new ArgumentException(nameof(length));
            if (str.Length > length) throw new ArgumentException("Длина строки больше существующего ограничения", nameof(str));
            return str;
        }
    }
}