using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskTable.Business.Concrete;
using TaskTable.Business.DIContainer;
using TaskTable.Business.Interfaces;

using TaskTable.DataAccess.Context;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Extensions;

namespace TaskTable.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();

            services.AddContainerWithDependecies();
            services.AddIdentityConfiguration();
            
            services.AddAutoMapper(typeof(Startup));
            // bir validatorda farklý nesne örneði alalým
            services.AddValidatorWithDependecies();
            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode","?code={0}");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                // MapAreaControllerRoute kullanýlýrsa area'a özgü olur route
                // her zaman özelden genele sýrasýyla yazýlmalý
                endpoints.MapControllerRoute(
                       name: "areas",
                       pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
