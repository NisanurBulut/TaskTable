using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.DataTransferObjects;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region UrgencyEntity-UrgencyDto
            CreateMap<UrgencyAddDto, UrgencyEntity>();
            CreateMap<UrgencyEntity, UrgencyAddDto>();
            CreateMap<UrgencyEditDto, UrgencyEntity>();
            CreateMap<UrgencyEntity, UrgencyEditDto>();
            CreateMap<UrgencyListDto, UrgencyEntity>();
            CreateMap<UrgencyEntity, UrgencyListDto>();
            #endregion
            #region TaskEntity-TaskDto
            CreateMap<TaskEntity, TaskAddDto>();
            CreateMap<TaskAddDto, TaskEntity>();
            CreateMap<TaskEntity, TaskEditDto>();
            CreateMap<TaskEditDto, TaskEntity>();
            CreateMap<TaskEntity, TaskListDto>();
            CreateMap<TaskListDto, TaskEntity>();
            #endregion
            #region AppUser-AppUserDto
            CreateMap<AppUserDto, AppUser>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion
            #region NotificationEntity-NotificatonDto
            CreateMap<NotificationEntity, NotificationListDto>();
            CreateMap<NotificationListDto, NotificationEntity>();
            #endregion
            #region ReportEntity-ReportDto
            CreateMap<ReportEntity, ReportAddDto>();
            CreateMap<ReportAddDto, ReportEntity>();
            CreateMap<ReportEntity, ReportEditDto>();
            CreateMap<ReportEditDto, ReportEntity>(); 
            #endregion
        }
    }
}
