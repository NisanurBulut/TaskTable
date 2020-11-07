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
using TaskTable.Web.StringInfo;

namespace TaskTable.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    // area kavramı yalnızca controllera özgüdür
    // viewcomponentlerde kullanılamaz
    // her view component'in bir default'ı olmalıdır.
    public class HomeController : BaseIdentityController
    {
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
            var user = await GetOnlineUser();
            ViewBag.NotAssignTaskCount = _taskService.GetNotAssignTaskCount();
            ViewBag.ComplatedAssignTaskCount = _taskService.GetComplatedAssignTaskCount();
            ViewBag.NotCompletedTaskCount = _taskService.GetNotCompletedTaskCount();
            ViewBag.UnReadNotificationCount = _notificationService.GetUnReadNotificationCountwithAppUserId(user.Id);
            ViewBag.ReportCount = _reportService.GetReportsCount();
            return View();
        }
    }
}
