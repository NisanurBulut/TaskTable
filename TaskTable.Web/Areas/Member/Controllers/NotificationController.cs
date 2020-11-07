using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.DataTransferObjects.DtoNotification;
using TaskTable.Entity.Concrete;
using TaskTable.Web.BaseControllers;
using TaskTable.Web.StringInfo;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    // area kavramı yalnızca controllera özgüdür
    // viewcomponentlerde kullanılamaz
    // her view component'in bir default'ı olmalıdır.
    public class NotificationController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService,
            UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = TempDataInfo.Notification;
            var user = await GetOnlineUser();
            var notificationList = _notificationService.GetUnReadAll(user.Id);
            var models = _mapper.Map<List<NotificationListDto>>(notificationList);
            
           
            return View(models);
        }
        [HttpPost]
        public IActionResult ReadNotification(int id)
        {
            var notification = _notificationService.Get(id);
            notification.State = true;
            _notificationService.Update(notification);
            return RedirectToAction("Index");
        }
    }
}
