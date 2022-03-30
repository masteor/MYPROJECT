namespace QWERTY.Shared.Db.Validation
{
    public abstract class Validator
    {
        protected static string СООБЩЕНИЕ_НЕДОПУСТИМОЕ_ЗНАЧЕНИЕ_NULL { get; } = "недопустимое значение null";
        public static string СТРОКА_IsNullOrWhiteSpace { get; } = "строка IsNullOrWhiteSpace";
        protected static string СООБЩЕНИЕ_СТРОКА_НУЛЕВОЙ_ДЛИНЫ { get; } = "строка нулевой длины";
        private static string СООБЩЕНИЕ_ДАТА_МИНИМАЛЬНОГО_ЗНАЧЕНИЯ { get; } = "дата имеет недопустимое минимальное значение";

        internal const bool DebugModeOn = true;
    }
}