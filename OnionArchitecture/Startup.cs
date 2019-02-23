using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Owin;

namespace OnionArchitecture
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          
            AutoMapperConfiguration.Configure();

            ConfigureAuth(app);
        }
    }
}
