
namespace eShopWinForms.Modules
{
    public class ApplicationModule
    {
        private bool useMockData;

        public ApplicationModule(bool useMockData)
        {
            this.useMockData = useMockData;
        }
        protected void Load()
        {
           /* if (this.useMockData)
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
                .InstancePerLifetimeScope();

            builder.RegisterType<CatalogDBInitializer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CatalogItemHiLoGenerator>()
                .SingleInstance();*/
        }
    }
}