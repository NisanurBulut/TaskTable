using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddScoped<ITaskService,TaskManager>(); // isteði gerçekleþtiren session da ilgili nesneden sadece bir tane örnek alýnýr, transient ta ise her istekte bir örnek alýnýr, singletonda devamlý ayný örnek kullanýlýr nesne için
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddDbContext<DatabaseContext>();

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUrgencyRepository, UrgencyRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DatabaseContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // MapAreaControllerRoute kullanýlýrsa area'a özgü olur route
                // her zaman özelden genele sýrasýyla yazýlmalý
                endpoints.MapControllerRoute(
                       name: "areas",
                       pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
