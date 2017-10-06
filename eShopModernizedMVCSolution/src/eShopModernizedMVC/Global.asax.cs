using Autofac;
using Autofac.Integration.Mvc;
using eShopModernizedMVC.Models;
using eShopModernizedMVC.Models.Infrastructure;
using eShopModernizedMVC.Modules;
using eShopModernizedMVC.Services;
using Microsoft.Diagnostics.EventFlow;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace eShopModernizedMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IContainer container;
        private DiagnosticPipeline diagnosticsPipeline;

        protected void Application_Start()
        {
            container = RegisterContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigDataBase();
            InitializeCatalogImages();
            InitializePipeline();
        }

        /// <summary>
        /// http://docs.autofac.org/en/latest/integration/mvc.html
        /// </summary>
        protected IContainer RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new ApplicationModule(CatalogConfiguration.UseMockData, CatalogConfiguration.UseAzureStorage));

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var raisedException = Server.GetLastError();
            Trace.TraceError($"Unhandled exeption: {raisedException}");
        }

        private void ConfigDataBase()
        {
            if (!CatalogConfiguration.UseMockData)
            {
                Database.SetInitializer<CatalogDBContext>(container.Resolve<CatalogDBInitializer>());
            }
        }

        private void InitializeCatalogImages()
        {
            var imageService = container.Resolve<IImageService>();
            imageService.InitializeCatalogImages();
        }

        private void InitializePipeline()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("eventFlowConfig.json", optional: true, reloadOnChange: true)
                .Build();
            var environmentKey = CatalogConfiguration.AppInsightsInstrumentationKey;

            if (!string.IsNullOrEmpty(environmentKey))
            {
                configuration["outputs:0:instrumentationKey"] = environmentKey;
            }

            diagnosticsPipeline = DiagnosticPipelineFactory.CreatePipeline(configuration);
        }
    }
}
