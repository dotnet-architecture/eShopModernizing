using Autofac;
using eShopPorted.Models;
using eShopPorted.Models.Infrastructure;
using eShopPorted.Services;

namespace eShopPorted.Modules
{
    public class ApplicationModule : Module
    {
        private bool _useMockData;
        private readonly string _connectionString;

        public ApplicationModule(bool useMockData, string connectionString)
        {
            _useMockData = useMockData;
            _connectionString = connectionString;
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

            builder.RegisterType<CatalogDBContext>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<CatalogDBInitializer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CatalogItemHiLoGenerator>()
                .SingleInstance();
        }
    }
}