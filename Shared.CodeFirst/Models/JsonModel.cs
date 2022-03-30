namespace QWERTY.Shared.Models
{
    public class JsonModel
    {
        public struct Result
        {
            private Codes _code;
            public int code
            {
                get => (int) _code;
                set => _code = (Codes) value;
            }

            public string msg { get; set; }
            public string details { get; set; }
        }

        public enum Codes
        {
            success = 200,
            error_500 = 500
        }

        
        private static object СоздатьСообщение(int code, object? data, string? msg) 
            => new {
                model = data,
                result = new Result
                {
                    code = code,
                    msg = msg
                }
            };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static object СоздатьУспешноеСообщение(object? data, string? msg = "Успех") 
            => 
                СоздатьСообщение((int) Codes.success, data, msg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static object СоздатьСообщениеОбОшибке(object? data, string? msg)
            =>
                СоздатьСообщение((int) Codes.error_500, data, msg);
    }
}