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
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        public TaskOrderController(IAppUserService appUserService,
            ITaskService taskService, UserManager<AppUser> userManager,
            IFileService fileService,
            IReportService reportService,
            INotificationService notificationService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _taskService = taskService;
            _fileService = fileService;
            _reportService = reportService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "taskorder";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var tasklist = _taskService.GetAllTasksWithAllProperties(I => I.AppUserId == user.Id && I.Durum == false);
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
            // byte döndüğü için doğrudan report return edilebilir
            return File(_fileService.ExportExcel(_taskService.GetTaskWithReportProperty(id).Reports),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new Guid() + ".xlsx");
        }
        public IActionResult ExportPdf(int id)
        {
            var filePath = _fileService.ExportExcel(_taskService.GetTaskWithReportProperty(id).Reports);
            return File(filePath, "application/pdf", new Guid() + ".pdf");
        }

        // buradaki id aslında taskId
        public IActionResult AddReport(int id)
        {
            TempData["active"] = "taskorder";
            ReportAddViewModel model = new ReportAddViewModel();
            model.TaskId = id;
            model.Task = _taskService.GetTaskWithUrgencyProperty(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                ReportEntity entity = new ReportEntity
                {
                    TaskId = model.TaskId,
                    Detail = model.Detail,
                    Description = model.Description

                };
                _reportService.Add(entity);
                // rolü admin olan kullanıcılara bildirim eklenecek
                var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);
                foreach (var adminUser in adminUsers)
                {
                    _notificationService.Add(new NotificationEntity
                    {
                        State = false,
                        AppUserId = adminUser.Id,
                        Description = $"{activeUser.Name} {activeUser.Surname} yeni bir rapor yazdı."
                    });
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // 
        public IActionResult EditReport(int id)
        {
            TempData["active"] = "taskorder";
            ReportEntity entity = new ReportEntity();
            entity = _reportService.GetReportWithTaskProperty(id);
            ReportEditViewModel model = new ReportEditViewModel();
            model.TaskId = id;
            model.Id = entity.Id;
            model.Task = entity.Task;
            model.TaskId = entity.TaskId;
            model.Detail = entity.Detail;
            model.Description = entity.Description;
            return View(model);
        }
        [HttpPost]
        public IActionResult EditReport(ReportEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _reportService.Get(model.Id);
                entity.Detail = model.Detail;
                entity.Description = model.Description;

                _reportService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> CompleteTask(int TaskId)
        {
            if (ModelState.IsValid)
            {
                var entity = _taskService.Get(TaskId);
                entity.Durum = true;

                _taskService.Update(entity);

                var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);
                foreach (var adminUser in adminUsers)
                {
                    _notificationService.Add(new NotificationEntity
                    {
                        State = false,
                        AppUserId = adminUser.Id,
                        Description = $"{activeUser.Name} {activeUser.Surname} görevi tamamladı."
                    });
                }
                return RedirectToAction("Index");
            }
            return Json(null);
        }
    }
}
