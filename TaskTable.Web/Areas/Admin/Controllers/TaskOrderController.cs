using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.Web.Areas.Admin.Models;
namespace TaskTable.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;
        public TaskOrderController(IAppUserService appUserService, ITaskService taskService)
        {
            _appUserService = appUserService;
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "taskorder";
            var tasklist = _taskService.GetAllTasksWithAllProperties();
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
            var model = _appUserService.GetNotAdminAppUsers();
            return View(models);
        }
        public IActionResult AssignUser(int id)
        {
            var entity = _taskService.GetTaskWithUrgencyProperty(id);
            TaskListViewModel model = new TaskListViewModel
            {
                Aciklama = entity.Aciklama,
                Ad = entity.Ad,
                Id = entity.Id,
                Urgency = entity.Urgency,
                OlusturulmaTarihi=entity.OlusturulmaTarihi
            };
            return View(model);
        }
    }
}
