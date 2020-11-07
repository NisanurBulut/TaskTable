using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Business.Concrete;
using TaskTable.Business.Interfaces;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.DataAccess.Repository;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.Extensions
{
    public static class CollecttionExtension
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
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
                opt.Cookie.SameSite = SameSiteMode.Strict; // cookie başka sitelerle paylaşılmasın
                opt.Cookie.HttpOnly = true; //kullanıcı cookieye erişemesin
                opt.ExpireTimeSpan = TimeSpan.FromDays(20); // cookie ömrü
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }
    }
}
