using System.Web.Routing;

namespace QWERTY.Web.Models.Общие
{
    public class String_model
    {
        public string report_name { get; set; }
        public String_model() => report_name = string.Empty;
        public String_model(string reportName = null) => report_name = reportName;

        public RouteValueDictionary ToRouteValueDictionary()
        {
            var routeValues = new RouteValueDictionary
            {
                {$"{nameof(report_name)}", report_name},
            };
            return routeValues;
        }
    }
}