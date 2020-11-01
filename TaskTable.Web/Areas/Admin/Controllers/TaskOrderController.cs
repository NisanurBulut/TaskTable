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
namespace TaskTable.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;
        private readonly UserManager<AppUser> _userManager;
        public TaskOrderController(IAppUserService appUserService, ITaskService taskService, UserManager<AppUser> userManager, IFileService fileService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _taskService = taskService;
            _fileService = fileService;
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
        public IActionResult AssignUser(int id, string searchKey, int page = 1)
        {
            TempData["active"] = "taskorder";
            ViewBag.ActivePage = page;
            int totalPage = 0;
            var entity = _taskService.GetTaskWithUrgencyProperty(id);
            var kullaniciEntities = _appUserService.GetNotAdminAppUsers(out totalPage, searchKey, page);
            ViewBag.TotalPage = totalPage;
            ViewBag.SearchKey = searchKey;
            List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            foreach (var item in kullaniciEntities)
            {
                AppUserListViewModel modelAppUser = new AppUserListViewModel
                {
                    Email = item.Email,
                    Name = item.Name,
                    Surname = item.Surname,
                    Id = item.Id,
                    Picture = item.Picture
                };
                appUserListModel.Add(modelAppUser);
            }
            ViewBag.Kullanicilar = appUserListModel;
            TaskListViewModel model = new TaskListViewModel
            {
                Aciklama = entity.Aciklama,
                Ad = entity.Ad,
                Id = entity.Id,
                Urgency = entity.Urgency,
                OlusturulmaTarihi = entity.OlusturulmaTarihi
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult AssignTaskToUser(TaskAssignUserViewModel model)
        {
            TempData["active"] = "taskorder";
            var user = _userManager.Users.FirstOrDefault(a => a.Id == model.AppUserId);
            var task = _taskService.GetTaskWithUrgencyProperty(model.TaskId);
            AppUserListViewModel userModel = new AppUserListViewModel();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.Surname = user.Surname;
            userModel.Picture = user.Picture;
            userModel.Email = user.Email;

            TaskListViewModel taskListViewModel = new TaskListViewModel();
            taskListViewModel.Aciklama = task.Aciklama;
            taskListViewModel.Ad = task.Ad;
            taskListViewModel.Urgency = task.Urgency;
            taskListViewModel.Id = task.Id;

            TaskAssignUserListViewModel taskUserViewModel = new TaskAssignUserListViewModel();
            taskUserViewModel.AppUser = userModel;
            taskUserViewModel.Task = taskListViewModel;
            return View(taskUserViewModel);
        }
        [HttpPost]
        public IActionResult AssignTaskOnUser(TaskAssignUserViewModel model)
        {
            var item = _taskService.Get(model.TaskId);
            item.AppUserId = model.AppUserId;
            _taskService.Update(item);
            return RedirectToAction("Index");
        }
        public IActionResult GiveDetail(int id)
        {
            TempData["active"] = "taskorder";
            var result = _taskService.GetTaskWithReportProperty(id);
            TaskListAllViewModel model = new TaskListAllViewModel();
            model.OlusturulmaTarihi = result.OlusturulmaTarihi;
            model.Id = result.Id;
            model.Reports = result.Reports;
            model.Aciklama = result.Aciklama;
            model.Ad = result.Ad;
            model.AppUser = result.AppUser;
            return View(model);
        }
        public IActionResult ExportExcel(int id)
        {
            TempData["active"] = "taskorder";
            // byte döndüğü için doğrudan report return edilebilir
            return File(_fileService.ExportExcel(_taskService.GetTaskWithReportProperty(id).Reports),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new Guid() + ".xlsx");
        }
        public IActionResult ExportPdf(int id)
        {
            TempData["active"] = "taskorder";
            var filePath = _fileService.ExportExcel(_taskService.GetTaskWithReportProperty(id).Reports);
            return File(filePath, "application/pdf", new Guid() + ".pdf");
        }
    }
}
