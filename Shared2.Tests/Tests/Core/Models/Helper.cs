using QWERTY.Shared.Models;
using QWERTY.Shared.Models._Создатель;
using NUnit.Framework;

namespace QWERTY.Shared2.Tests.Tests.Core.Models
{
    public class Helper
    {
        internal static void AssertResults<T>(TestDelegate testDelegate,
            T? t, object? jsonМодель) where T : Создатель<ДанныеИзФормы>
        {
            Assert.IsNotNull(t, $"конструктор [{nameof(T)}] не создался");
            Assert.IsNull(t?.Ошибка, t?.Ошибка?.ToString());
            
            Assert.IsNotNull(jsonМодель, "jsonМодель не должна быть нулл");
            
            Assert.True(jsonМодель?.GetType().GetProperties()[0].Name == "model");
            Assert.True(jsonМодель?.GetType().GetProperties()[1].Name == "result");
            Assert.True(jsonМодель?.GetType().GetProperties()[1].GetValue(jsonМодель).GetType().GetProperties()[0].Name ==
                        "code");
            Assert.True(
                jsonМодель?.GetType().GetProperties()[1].GetValue(jsonМодель).GetType().GetProperties()[1].Name == "msg");
            Assert.True(jsonМодель?.GetType().GetProperties()[1].GetValue(jsonМодель).GetType().GetProperties()[2].Name ==
                        "details");
        }
    }
}