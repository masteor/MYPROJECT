using System;
using QWERTY.Shared.Log;
using QWERTY.Shared.Models;
using static QWERTY.Shared.Models.JsonModel.Codes;

namespace QWERTY.Shared.Helpers
{
    public class JsonHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="объект"></param>
        /// <param name="ex"></param>
        /// <param name="сообщениеВоСлучаеУспеха"></param>
        /// <returns></returns>
        public static object СоздатьJsonМодель(object? объект, Exception? ex, string? сообщениеВоСлучаеУспеха) =>
            new 
            {
                model = ex switch 
                {
                    null => объект,
                    _ => null
                },
                result = ВернутьРезультатJsonModel(сообщениеВоСлучаеУспеха, ex)
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="сообщениеВоСлучаеУспеха"></param>
        /// <returns></returns>
        public static object СоздатьJsonМодель(Exception? ex, string? сообщениеВоСлучаеУспеха) =>
            СоздатьJsonМодель(null, ex, сообщениеВоСлучаеУспеха);
        
        
        public static object СоздатьJsonМодель(Exception? ex) =>
            СоздатьJsonМодель(null, ex, null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="сообщениеВоСлучаеУспеха"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static JsonModel.Result ВернутьРезультатJsonModel(string? сообщениеВоСлучаеУспеха, Exception? ex)
        {
            var code = (int) success;
            var msg = сообщениеВоСлучаеУспеха ?? "<пустое сообщение>";
            var details = "";
            
            try
            {
                if (ex != null)
                {
                    code = (int) error_500;
                    msg = HelpLogger.СобратьВсеПодчиненныеОшибки(ex);
                    details = ex.StackTrace;
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                details = e.StackTrace;
            }

            return new JsonModel.Result
            {
                code = code,
                msg = msg,
                details = details
            };
        }
    }
}