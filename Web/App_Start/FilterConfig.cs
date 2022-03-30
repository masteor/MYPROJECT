using System.Web.Mvc;

namespace QWERTY.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(filter: new HandleErrorAttribute());
        }
    }
}
