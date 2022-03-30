using System;
using QWERTY.Shared.Extensions;

namespace QWERTY.Shared.Models
{
    public class ЧекнутьДанные<T> where T : ДанныеИзФормы
    {
        private Exception? Ошибка { get; set; }
        private const string МОДЕЛЬ_НЕ_ВАЛИДНА = "Модель не валидна";

        public ЧекнутьДанные(T? модель)
        {
            // _log = log;
            
            try
            {
                if (модель == null)
                    throw new ArgumentException($"{nameof(модель)} не может быть нулл");
                
                if (модель.id != null && модель.id < 1)
                    throw new ArgumentOutOfRangeException(nameof(модель.id));

                if (модель.request_params.IsNull())
                    throw new ArgumentException($"{модель.GetType().FullName} [request_params] не может быть нулл");

                // получаем тип проверяемой модели
                string s = модель.GetType().FullName;
                
                if (модель.Валидна().Нет())
                    throw new ArgumentException
                    ($"{МОДЕЛЬ_НЕ_ВАЛИДНА}: {s}  " +
                              $"{(модель.получитьИсключение == null ? "<Не удалось получить исключение>" : модель.получитьИсключение!.Message)}" ,
                        модель.получитьИсключение);
            }
            catch (Exception e)
            {
                Ошибка = e;
                throw;
            }
        }
    }
}