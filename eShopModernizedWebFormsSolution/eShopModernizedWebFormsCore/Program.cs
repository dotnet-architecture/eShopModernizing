
using Autofac.Extensions.DependencyInjection;
using Autofac;
using System.Web.UI;
using eShopModernizedWebForms.Modules;
using eShopModernizedWebFormsCore;
using eShopModernizedWebForms;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddWebConfig();
builder.Services.AddConfigurationManager();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new ApplicationModule(CatalogConfiguration.UseMockData, CatalogConfiguration.UseAzureStorage, CatalogConfiguration.UseManagedIdentity));
    });


builder.Services.AddSystemWebAdapters()
    .AddWebForms()
    .AddDynamicPages(options =>
    {
        options.AddTypeNamespace(typeof(ScriptManager), "asp");
    })
    .AddJsonSessionSerializer(options =>
    {
        options.RegisterKey<string>("MachineName");
        options.RegisterKey<DateTime>("SessionStartTime");
    })
    .AddRemoteAppClient(options =>
    {
        options.ApiKey = builder.Configuration["RemoteApiKey"];
        options.RemoteAppUrl = new(builder.Configuration["ReverseProxy:Clusters:fallbackCluster:Destinations:fallbackApp:Address"]);
    })
    .AddSessionClient()
    .AddAuthenticationClient(true);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use((ctx, next) =>
{
    if (ctx.Request.Path == "/Catalog/Create")
    {
        ctx.Request.Path = "/Catalog/Create.aspx";
    }

    return next(ctx);
});

app.UseWebFormsScripts();

app.UseRouting();

// Use cookies to disable endpoints
app.Use((ctx, next) =>
{
    var j = ctx.RequestServices.GetRequiredService<IConfiguration>();
    var config = System.Configuration.ConfigurationManager.AppSettings;
    var s = System.Configuration.ConfigurationManager.ConnectionStrings;

    if (ctx.Request.Cookies.TryGetValue("skip_core", out var existing) && bool.TryParse(existing, out var result) && result)
    {
        ctx.SetEndpoint(null);
    }

    return next(ctx);
});

app.UseAuthorization();
app.UseSystemWebAdapters();

app.MapDynamicAspxPages(app.Environment.ContentRootFileProvider)
    .InjectProperties();
app.MapReverseProxy();

app.Run();
