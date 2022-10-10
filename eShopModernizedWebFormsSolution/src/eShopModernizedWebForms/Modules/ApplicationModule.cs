﻿using Autofac;
using eShopModernizedWebForms.Models;
using eShopModernizedWebForms.Models.Infrastructure;
using eShopModernizedWebForms.Services;

namespace eShopModernizedWebForms.Modules
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

#if NETFRAMEWORK
            if (this.useAzureStorage)
            {
                builder.RegisterType<ImageAzureStorage>()
                    .As<IImageService>()
                    .InstancePerLifetimeScope();
            }
            else
#endif
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

#if NETFRAMEWORK
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
#else
            builder.RegisterInstance(new ConnectionStringFactory("Server=tcp:127.0.0.1,5433;Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb;User Id=sa;Password=Pass@word"))
                .As<ISqlConnectionFactory>();
#endif
        }
    }
}