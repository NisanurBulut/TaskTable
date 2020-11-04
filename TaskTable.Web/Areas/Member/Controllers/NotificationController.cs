using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    // area kavramı yalnızca controllera özgüdür
    // viewcomponentlerde kullanılamaz
    // her view component'in bir default'ı olmalıdır.
    public class NotificationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "notification";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var notificationList = _notificationService.GetUnReadAll(user.Id);
            var models = new List<NotificationListViewModel>();
            foreach(var item in notificationList)
            {
                var model = new NotificationListViewModel
                {
                    Id = item.Id,
                    Description = item.Description
                };
                models.Add(model);
            }
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
