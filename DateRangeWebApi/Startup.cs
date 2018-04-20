using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateRangeWebApi.DataLayer.Entities;
using DateRangeWebApi.Repository.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RepositoryGeneric;
using DateRangeWebApi.Service.ServiceMapper;
using DateRangeWebApi.Service.ServiceStorage;
using System.Globalization;

namespace DateRangeWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext
            services.AddDbContext<DateRangeContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DateRangeConnection"),
            opt=>opt.MigrationsAssembly("DateRangeWebApi.DataLayer")));
            services.AddScoped<DbContext, DateRangeContext>();
            // Add RepositoryContext, ServiceMappers, RepoServices
            services.AddTransient<IRepositoryContextBase, RepositoryContext>();
            services.AddTransient<IDateRangeMapper, DateRangeMapper>();
            services.AddTransient<IDateRangeService, DateRangeService>();
            // Add localization services
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("uk-UA");
                options.SupportedCultures = new List<CultureInfo> {new CultureInfo("uk-UA") };
                options.RequestCultureProviders.Clear();
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DateRangeContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Apply migrations and seed initial data
            DateRangeContextInitializer.Initialize(context);
            // Use localization middleware
            app.UseRequestLocalization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "api",
                    template: "api/{controller=daterange}/{action}/{id?}");
            });
        }
    }
}
