using Autofac;
using Autofac.Integration.Mvc;
using eShopModernizedMVC.Models;
using eShopModernizedMVC.Models.Infrastructure;
using eShopModernizedMVC.Modules;
using eShopModernizedMVC.Services;
using log4net;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace eShopModernizedMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        IContainer container;

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
        /// Track the machine name and the start time for the session inside the current session
        /// </summary>
        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session["MachineName"] = Environment.MachineName;
            HttpContext.Current.Session["SessionStartTime"] = DateTime.Now;
        }

        /// <summary>
        /// http://docs.autofac.org/en/latest/integration/mvc.html
        /// </summary>
        protected IContainer RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new ApplicationModule(CatalogConfiguration.UseMockData, CatalogConfiguration.UseAzureStorage, CatalogConfiguration.UseManagedIdentity));

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var raisedException = Server.GetLastError();
            Trace.TraceError($"Unhandled exeption: {raisedException}");
            _log.Error($"Unhandled exception typeof({raisedException.GetType().Name}): {raisedException.Message}");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //set the property to our new object
            LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();

            LogicalThreadContext.Properties["requestinfo"] = new WebRequestInfo();

            _log.Debug("WebApplication_BeginRequest");
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
