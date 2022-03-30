using AutoFixture;
using QWERTY.Shared.Enums;
using QWERTY.Shared.Models;
using static QWERTY.Shared2.Tests.Tests.Core.Models.Модульные_Тесты.InitModule;

namespace QWERTY.Shared2.Tests.Обслуживание_Тестов
{
    public static class ГенераторМоделей
    {
        /*public static string ПолучитьВалидныйЛогин(int? длинаСимволов = Annotation.login_name.MaxLength) => 
            _fixture
                .Create<string>()
                .Substring(0, (int) длинаСимволов);*/

        public static string ПолучитьВалидныйЕмайл(int? длинаСимволов = Annotation.email.MaxLength, string? myfixture = null)
        {
            const string sabaka = "@sils.local";
            if (длинаСимволов <= sabaka.Length) return "1" + sabaka;
            
            var f = (myfixture ?? ПолучитьФикстуру<string>()) ?? "2";
            if (f.Length + sabaka.Length <= длинаСимволов) return f + sabaka;
            return f.Substring(0, (int) (длинаСимволов - sabaka.Length)) + sabaka;
        }
    }
}