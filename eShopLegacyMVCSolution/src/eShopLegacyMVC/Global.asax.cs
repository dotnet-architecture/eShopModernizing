using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using eShopLegacyMVC.Models;
using eShopLegacyMVC.Models.Infrastructure;
using eShopLegacyMVC.Modules;
using log4net;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace eShopLegacyMVC
{
    public class MvcApplication : HttpApplication
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        IContainer container;

        protected void Application_Start()
        {
            container = RegisterContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigDataBase();
        }

        /// <summary>
        /// Track the machine name and the start time for the session inside the current session
        /// </summary>
        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Session["MachineName"] = Environment.MachineName;
            HttpContext.Current.Session["SessionStartTime"] = DateTime.Now;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //set the property to our new object
            LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();

            LogicalThreadContext.Properties["requestinfo"] = new WebRequestInfo();

            _log.Debug("WebApplication_BeginRequest");
        }

        /// <summary>
        /// http://docs.autofac.org/en/latest/integration/mvc.html
        /// </summary>
        protected IContainer RegisterContainer()
        {
            var builder = new ContainerBuilder();

            var thisAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(thisAssembly);
            builder.RegisterApiControllers(thisAssembly);

            var mockData = bool.Parse(ConfigurationManager.AppSettings["UseMockData"]);
            builder.RegisterModule(new ApplicationModule(mockData));

            var container = builder.Build();

            // set mvc resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // set webapi resolver
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }

        private void ConfigDataBase()
        {
            var mockData = bool.Parse(ConfigurationManager.AppSettings["UseMockData"]);

            if (!mockData)
            {
                Database.SetInitializer<CatalogDBContext>(container.Resolve<CatalogDBInitializer>());
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
