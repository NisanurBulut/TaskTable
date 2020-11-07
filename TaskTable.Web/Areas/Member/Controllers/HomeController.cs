using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;
using TaskTable.Web.BaseControllers;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : BaseIdentityController
    {
        /*
         İlgili kullanıcının rapor sayısı
         İlgili kullanıcının bildirim sayısı
         İlgili kullanıcının görev sayısı
         */
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        public HomeController(IReportService reportService, 
            UserManager<AppUser> userManager, ITaskService taskService,
            INotificationService notificationService):base(userManager)
        {
          
            _reportService = reportService;
            _taskService = taskService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "home";
            var user = GetOnlineUser();
            ViewBag.ReportCount = _reportService.GetReportsCountWithAppUserIdProperty(user.Id);
            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCountWithAppUserIdProperty(user.Id);
            ViewBag.UnReadNotificationCount = _notificationService.GetUnReadNotificationCountwithAppUserId(user.Id);
            ViewBag.UnCompletedTaskCount = _taskService.GetUnCompletedTaskCountWithAppUserIdProperty(user.Id);
            return View();
           
        }
    }
}
