using System;
using System.Globalization;
using System.Web.Routing;

namespace QWERTY.Web.Models.Общие
{
    public class DateTime_model
    {
        public DateTime? date_time { get; set; }
        public DateTime_model() => date_time = null;
        public DateTime_model(DateTime? dateTime) => date_time = dateTime;

        public RouteValueDictionary ToRouteValueDictionary()
        {
            var routeValues = new RouteValueDictionary
            {
                // warn: нужно использовать ТОЛЬКО CultureInfo.InvariantCulture, иначе дата не будет передаваться
                {$"{nameof(date_time)}", Convert.ToString(value: date_time, provider: CultureInfo.InvariantCulture)} 
                /*{$"datetime", $"{datetime:dd/MM/yyyy}"}*/
            };
            return routeValues;
        }
    }
}