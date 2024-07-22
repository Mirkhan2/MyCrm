using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCrm.Data;
using MyCrm.IoC;

namespace MyCrm.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Services
            services.AddControllersWithViews();

            #endregion

            #region IoC
            
            RegisterServices(services);

            #endregion

            #region Dd Context
            services.AddDbContext<CrmContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyCrmDbConnection"));
            });
            #endregion


            #region


            #endregion

            #region
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseRouting();

            //olgo bray roiting
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                    name : "default",
                    pattern: "{controller= Home}/{action=Index}/{Id}");
            });

        }
        #region register service method

        public static void RegisterServices(IServiceCollection services)
        {
            DependencyContainers.RegisterServices(services);
        }
        #endregion
    }
}