using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SisConv.Mvc.Startup))]
namespace SisConv.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
