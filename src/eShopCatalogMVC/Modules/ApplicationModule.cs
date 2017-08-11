using Autofac;
using eShopCatalogMVC.Services;

namespace eShopCatalogMVC.Modules
{
    public class ApplicationModule : Module
    {
        private bool useMockData;

        public ApplicationModule(bool useMockData)
        {
            this.useMockData = useMockData;
        }
        protected override void Load(ContainerBuilder builder)
        {
            if (this.useMockData)
            {
                builder.RegisterType<CatalogServiceMock>()
                    .As<ICatalogService>()
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<CatalogService>()
                    .As<ICatalogService>();
            }

        }
    }
}