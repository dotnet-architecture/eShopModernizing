using Autofac;
using Autofac.Integration.Web;
using eShopModernizedWebForms.Models;
using eShopModernizedWebForms.Models.Infrastructure;
using eShopModernizedWebForms.Modules;
using eShopModernizedWebForms.Services;
using log4net;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace eShopModernizedWebForms
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static IContainerProvider _containerProvider;
        IContainer container;

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

        /// <summary>
        /// Track the machine name and the start time for the session inside the current session
        /// </summary>
        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session["MachineName"] = Environment.MachineName;
            HttpContext.Current.Session["SessionStartTime"] = DateTime.Now;
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

            //set the property to our new object
            LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();

            LogicalThreadContext.Properties["requestinfo"] = new WebRequestInfo();

            _log.Debug("Application_BeginRequest");
        }

        /// <summary>
        /// http://docs.autofac.org/en/latest/integration/webforms.html
        /// </summary>
        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule(CatalogConfiguration.UseMockData, CatalogConfiguration.UseAzureStorage, CatalogConfiguration.UseManagedIdentity));
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
            TelemetryConfiguration.Active.TelemetryInitializers
                .Add(new MyTelemetryInitializer());
            var environmentKey = CatalogConfiguration.AppInsightsInstrumentationKey;

            if (!string.IsNullOrEmpty(environmentKey))
            {
                TelemetryConfiguration.Active.InstrumentationKey = environmentKey;
            }
        }
    }

    public class ActivityIdHelper
    {
        public override string ToString()
        {
            if (Trace.CorrelationManager.ActivityId == Guid.Empty)
            {
                Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            }

            return Trace.CorrelationManager.ActivityId.ToString();
        }

    }
    public class WebRequestInfo
    {
        public override string ToString()
        {
            return HttpContext.Current?.Request?.RawUrl + ", " + HttpContext.Current?.Request?.UserAgent;
        }
    }
}