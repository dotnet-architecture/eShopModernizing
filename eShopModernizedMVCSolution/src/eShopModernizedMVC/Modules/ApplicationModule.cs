using Autofac;
using eShopModernizedMVC.Models;
using eShopModernizedMVC.Models.Infrastructure;
using eShopModernizedMVC.Services;

namespace eShopModernizedMVC.Modules
{
    public class ApplicationModule : Module
    {
        private bool useMockData;
        private bool useAzureStorage;
        private bool useManagedIdentity;

        public ApplicationModule(bool useMockData, bool useAzureStorage, bool useManagedIdentity)
        {
            this.useMockData = useMockData;
            this.useAzureStorage = useAzureStorage;
            this.useManagedIdentity = useManagedIdentity;
        }
        protected override void Load(ContainerBuilder builder)
        {
            if (this.useMockData)
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

            if (this.useAzureStorage)
            {
                builder.RegisterType<ImageAzureStorage>()
                    .As<IImageService>()
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<ImageMockStorage>()
                  .As<IImageService>()
                  .InstancePerLifetimeScope();
            }


            builder.RegisterType<CatalogDBContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CatalogDBInitializer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CatalogItemHiLoGenerator>()
                .SingleInstance();

            if (this.useManagedIdentity)
            {
                builder.RegisterType<ManagedIdentitySqlConnectionFactory>()
                    .As<ISqlConnectionFactory>()
                    .SingleInstance();
            }
            else
            {
                builder.RegisterType<AppSettingsSqlConnectionFactory>()
                    .As<ISqlConnectionFactory>()
                    .SingleInstance();
            }
        }
    }
}