using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskTable.Business.Concrete;
using TaskTable.Business.Interfaces;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.DataAccess.Repository;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();

            services.AddScoped<ITaskService, TaskManager>(); // isteði gerçekleþtiren session da ilgili nesneden sadece bir tane örnek alýnýr, transient ta ise her istekte bir örnek alýnýr, singletonda devamlý ayný örnek kullanýlýr nesne için
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUrgencyRepository, UrgencyRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<DatabaseContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "TaskTableCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict; // cookie baþka sitelerle paylaþýlmasýn
                opt.Cookie.HttpOnly = true; //kullanýcý cookieye eriþemesin
                opt.ExpireTimeSpan = TimeSpan.FromDays(20); // cookie ömrü
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
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
