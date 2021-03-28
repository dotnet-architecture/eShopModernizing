using Autofac;
using Autofac.Extensions.DependencyInjection;
using eShopPorted.Models;
using eShopPorted.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShopPorted
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static DateTime StartTime { get; } = DateTime.UtcNow;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            bool useMockData = Configuration.GetValue<bool>("UseMockData");
            if (!useMockData)
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<CatalogDBContext>(options =>
                    options.UseSqlServer(connectionString)
                );
            }

            // Create Autofac container builder
            var builder = new ContainerBuilder();
            builder.Populate(services);
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
