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
using TaskTable.Web.Areas.Member.Models;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;
        private readonly UserManager<AppUser> _userManager;
        public TaskController(IAppUserService appUserService,
            ITaskService taskService, UserManager<AppUser> userManager, IFileService fileService, IReportService reportService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _taskService = taskService;
            _fileService = fileService;
            _reportService = reportService;
        }
        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["active"] = "task";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int totalPage = 0;
            var tasklist = _taskService.GetAllCompleteTasksWithAllProperties(out totalPage, user.Id, activePage);
            var models = new List<TaskListAllViewModel>();
            foreach (var item in tasklist)
            {
                TaskListAllViewModel taskModel = new TaskListAllViewModel
                {
                    Id = item.Id,
                    Aciklama = item.Aciklama,
                    Ad = item.Ad,
                    OlusturulmaTarihi = item.OlusturulmaTarihi,
                    Reports = item.Reports,
                    Urgency = item.Urgency,
                    AppUser = item.AppUser
                };
                models.Add(taskModel);
            }
            return View(models);
        }

    }
}
