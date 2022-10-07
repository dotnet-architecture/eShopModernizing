
using System.Web.UI;

var builder = WebApplication.CreateBuilder(args);

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

app.UseRouting();
app.UseAuthorization();
app.UseSystemWebAdapters();

app.MapDynamicAspxPages(app.Environment.ContentRootFileProvider);
app.MapReverseProxy();

app.Run();
