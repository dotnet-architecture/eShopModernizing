using Autofac;
using Autofac.Integration.Web;
using eShopModernizedWebForms.Models;
using eShopModernizedWebForms.Models.Infrastructure;
using eShopModernizedWebForms.Modules;
using eShopModernizedWebForms.Services;
using Microsoft.Diagnostics.EventFlow;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace eShopModernizedWebForms
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;
        IContainer container;
        private DiagnosticPipeline diagnosticsPipeline;

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureContainer();
            ConfigDataBase();
            InitializeCatalogImages();
            InitializePipeline();
            this.BeginRequest += Application_BeginRequest;
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var raisedException = Server.GetLastError();
            Trace.TraceError($"Unhandled exeption WebForms: {raisedException}");
        }

        protected virtual void Application_BeginRequest(object sender, EventArgs e)
        {
            var url = Request.Url.AbsoluteUri;
            Trace.TraceInformation($"Received request {url}.");
        }

        /// <summary>
        /// http://docs.autofac.org/en/latest/integration/webforms.html
        /// </summary>
        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule(CatalogConfiguration.UseMockData, CatalogConfiguration.UseAzureStorage));
            container = builder.Build();
            _containerProvider = new ContainerProvider(container);
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
            diagnosticsPipeline = DiagnosticPipelineFactory.CreatePipeline(".\\eventFlowConfig.json");
        }
    }
}