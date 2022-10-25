using Autofac;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System.Web;

namespace eShopModernizedWebForms
{
    public static class RequestExtensions
    {
        public static void Redirect(this System.Web.HttpResponse response, string path)
        {
            var core = (Microsoft.AspNetCore.Http.HttpResponse)response;
            var handler = ((System.Web.HttpContext)core.HttpContext).GetHandler();

            path = path.Trim('~');

            if (string.IsNullOrEmpty(path))
            {
                path = "/";
            }

            if (path[0] != '/')
            {
                path = "/" + path;
            }

            core.Redirect(path);
            response.End();
        }
    }
}

namespace eShopModernizedWebFormsCore
{
    public static class PageEndpointExtensions
    {
        public static IEndpointConventionBuilder InjectProperties(this IEndpointConventionBuilder builder)
        {
            builder.Add(builder =>
            {
                if (builder.RequestDelegate is { } current)
                {
                    builder.RequestDelegate = ctx =>
                    {
                        if (((System.Web.HttpContext)ctx).GetHandler() is { } handler)
                        {
                            var scope = ctx.RequestServices.GetRequiredService<ILifetimeScope>();
                            scope.InjectUnsetProperties(handler);
                        }

                        return current(ctx);
                    };
                }
            });
            return builder;
        }
    }
}
