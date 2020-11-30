using Autofac;
using eShopPorted.Models;
using eShopPorted.Models.Infrastructure;
using eShopPorted.Services;

namespace eShopPorted.Modules
{
    public class ApplicationModule : Module
    {
        private bool _useMockData;

        public ApplicationModule(bool useMockData)
        {
            _useMockData = useMockData;
        }
        protected override void Load(ContainerBuilder builder)
        {
            if (_useMockData)
            {
                builder.RegisterType<CatalogServiceMock>()
                    .As<ICatalogService>()
                    .SingleInstance();
            }
            else
            {
                builder.RegisterType<CatalogService>()
                    .As<ICatalogService>()
                    .InstancePerLifetimeScope();
            }
        }
    }
}