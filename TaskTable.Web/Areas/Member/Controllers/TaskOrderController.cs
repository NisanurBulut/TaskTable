using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.DataTransferObjects;
using TaskTable.Entity.Concrete;
using TaskTable.Web.BaseControllers;
using TaskTable.Web.StringInfo;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class TaskOrderController : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public TaskOrderController(IAppUserService appUserService,
            ITaskService taskService, UserManager<AppUser> userManager,
            IFileService fileService,
            IReportService reportService,
            INotificationService notificationService,
            IMapper mapper):base(userManager)
        {
            _mapper = mapper;
           
            _appUserService = appUserService;
            _taskService = taskService;
            _fileService = fileService;
            _reportService = reportService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "taskorder";
            var user = await GetOnlineUser();
            var tasklist = _taskService.GetAllTasksWithAllProperties(I => I.AppUserId == user.Id && I.State == false);
            var models = _mapper.Map<List<TaskListDto>>(tasklist);
            return View(models);
        }
        public IActionResult AssignUser(int id, string searchKey, int page = 1)
        {
            TempData["active"] = TempDataInfo.TaskOrder;
            ViewBag.ActivePage = page;
            int totalPage = 0;
            var entity = _taskService.GetTaskWithUrgencyProperty(id);
            var kullaniciEntities = _appUserService.GetNotAdminAppUsers(out totalPage, searchKey, page);
            ViewBag.TotalPage = totalPage;
            ViewBag.SearchKey = searchKey;
            var appUserListModel = _mapper.Map<List<AppUserListDto>>(kullaniciEntities);
            
            ViewBag.Kullanicilar = appUserListModel;
            TaskListDto model = _mapper.Map<TaskListDto>(entity);
            return View(model);
        }
        [HttpGet]
        public IActionResult AssignTaskToUser(TaskAssignUserDto model)
        {
            TempData["active"] = TempDataInfo.TaskOrder;
            var user = _userManager.Users.FirstOrDefault(a => a.Id == model.AppUserId);
            var task = _taskService.GetTaskWithUrgencyProperty(model.TaskId);
            AppUserListDto userModel = _mapper.Map<AppUserListDto>(user);
            TaskListDto taskListDto = _mapper.Map<TaskListDto>(task);

            TaskAssignUserListDto taskUserViewModel = new TaskAssignUserListDto();
            taskUserViewModel.AppUser = userModel;
            taskUserViewModel.Task = taskListDto;
            return View(taskUserViewModel);
        }
        [HttpPost]
        public IActionResult AssignTaskOnUser(TaskAssignUserDto model)
        {
            var item = _taskService.Get(model.TaskId);
            item.AppUserId = model.AppUserId;
            _taskService.Update(item);
            return RedirectToAction("Index");
        }
        public IActionResult GiveDetail(int id)
        {
            TempData["active"] = TempDataInfo.TaskOrder;
            var result = _taskService.GetTaskWithReportProperty(id);
            var model = _mapper.Map<TaskListDto>(result);           
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
            TempData["active"] = TempDataInfo.TaskOrder;
            ReportAddDto model = new ReportAddDto();
            model.TaskId = id;
            model.Task = _taskService.GetTaskWithUrgencyProperty(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<ReportEntity>(model);
              
                _reportService.Add(entity);
                // rolü admin olan kullanıcılara bildirim eklenecek
                var adminUsers = await _userManager.GetUsersInRoleAsync(RoleInfo.Admin);
                var activeUser = await GetOnlineUser();
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
            TempData["active"] = TempDataInfo.TaskOrder;
            ReportEntity entity = new ReportEntity();
            entity = _reportService.GetReportWithTaskProperty(id);
            var model = _mapper.Map<ReportEditDto>(entity);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditReport(ReportEditDto model)
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
                var taskEntity = _taskService.Get(TaskId);
                taskEntity.State = true;
                _taskService.Update(taskEntity);

                var adminUsers = await _userManager.GetUsersInRoleAsync(RoleInfo.Admin);
                var activeUser = await GetOnlineUser();
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
