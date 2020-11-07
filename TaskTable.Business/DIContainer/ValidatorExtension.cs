using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.ValidationRules;
using TaskTable.DataAccess.Repository;
using TaskTable.DataTransferObjects;
namespace TaskTable.Business.DIContainer
{
    public static class ValidatorExtension
    {
        public static void AddValidatorWithDependecies(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UrgencyAddDto>, UrgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyEditDto>, UrgencyEditValidator>();
            services.AddTransient<IValidator<TaskAddDto>, TaskAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<AppUserDto>, AppUserValidator>();
            services.AddTransient<IValidator<TaskEditDto>, TaskEditValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportEditDto>, ReportEditValidator>();
        }
    }
}
