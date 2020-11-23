using Autofac;
using Autofac.Extensions.DependencyInjection;
using eShopPorted.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShopPorted
{
    public class Startup
    {
        public static DateTime StartTime { get; } = DateTime.UtcNow;
        public static string MachineName { get; } = Environment.MachineName;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Create Autofac container builder
            var builder = new ContainerBuilder();
            builder.Populate(services);
            bool useMockData = true; // TODO: read from config
            builder.RegisterModule(new ApplicationModule(useMockData));

            ILifetimeScope container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Catalog}/{action=Index}/{id?}");
            });
        }
    }
}
