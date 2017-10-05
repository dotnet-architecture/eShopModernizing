using System.Diagnostics;
using System.Web.Mvc;

namespace eShopModernizedMVC.Filters
{
    public class ActionTracerFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                Trace.TraceInformation($"Received request for action {filterContext.ActionDescriptor.ActionName} in controller {filterContext.Controller.GetType().Name}.");
                base.OnActionExecuting(filterContext);
        }
    }
}