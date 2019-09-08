using eShopModernizedMVC.Middleware;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(eShopModernizedMVC.Startup))]

namespace eShopModernizedMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            if (CatalogConfiguration.UseAzureActiveDirectory)
            {
                ConfigureAuth(app);
            }
            else
            {
                app.Use<AuthenticationMiddleware>();
            }
        }
    }
}
