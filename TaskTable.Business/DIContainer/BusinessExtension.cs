using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.Concrete;
using TaskTable.Business.Interfaces;
using TaskTable.Business.Logger;
using TaskTable.DataAccess.Interfaces;
using TaskTable.DataAccess.Repository;

namespace TaskTable.Business.DIContainer
{
    public static class BusinessExtension
    {
        public static void AddContainerWithDependecies(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskManager>(); // isteği gerçekleştiren session da ilgili nesneden sadece bir tane örnek alınır, transient ta ise her istekte bir örnek alınır, singletonda devamlı aynı örnek kullanılır nesne için
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUrgencyRepository, UrgencyRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddTransient<INLogger,NLogger>();
        }
    }
}
