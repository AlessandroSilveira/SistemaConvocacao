using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SisConv.Application.AutoMapper;
using SisConv.Infra.CrossCutting.Identity.Context;
using SisConv.Infra.CrossCutting.Identity.Helpers;

namespace SisConv.Mvc
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMapping();
            var context = new ApplicationDbContext();
            IdentityHelper.SeedIdentities(context);
        }
    }
}