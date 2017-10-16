using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(eShopModernizedWebForms.Startup))]

namespace eShopModernizedWebForms
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
