using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppsDemo.Startup))]
namespace WebAppsDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
