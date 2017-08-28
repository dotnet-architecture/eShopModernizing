using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace eShopLegacyWebForms
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "",
                "Default",
                "~/Default.aspx"
                );
            routes.MapPageRoute(
                "ProductsByPageRoute",
                "Default/index/{index}/size/{size}",
                "~/Default.aspx"
                );
        }
    }
}
