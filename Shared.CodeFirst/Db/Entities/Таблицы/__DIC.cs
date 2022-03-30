using System;
using QWERTY.Shared.Db.Validation;

namespace QWERTY.Shared.Db.Entities.Таблицы
{
    /// <summary>
    /// Словарь русских и английских слов
    /// </summary>
    public class DIC : _EntityBase
    {
        public int id { get; set; }
        public string rus 
        { 
            get => Valid(_rus, nameof(rus));
            set => _rus = Valid(value, nameof(rus));
        }
        public string eng 
        { 
            get => Valid(_eng, nameof(eng));
            set => _eng = Valid(value, nameof(eng));
        }

        private static string Valid(string s, string name)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentNullException(name, Validator.СТРОКА_IsNullOrWhiteSpace);
            return s
                .Replace("?", string.Empty)
                .Replace(".", string.Empty)
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace("!", string.Empty)
                .Replace("?", string.Empty)
                .Replace("/", string.Empty)
                .Replace("'", string.Empty);
        }

        private string? _rus;
        private string? _eng;
    }
}