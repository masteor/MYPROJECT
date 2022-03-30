using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QWERTY.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(filters: GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(routes: RouteTable.Routes);
            BundleConfig.RegisterBundles(bundles: BundleTable.Bundles);

            // configure dependency injection engine
            Bootstrapper.Run(settings: Properties.Settings.Default);
        }
    }
}
