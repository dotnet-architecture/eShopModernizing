using eShopModernizedMVC.Filters;
using System.Web.Mvc;

namespace eShopModernizedMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ActionTracerFilter());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new OutputCacheAttribute
            {
                VaryByParam = "*",
                Duration = 0,
                NoStore = true,
            });
        }
    }
}
