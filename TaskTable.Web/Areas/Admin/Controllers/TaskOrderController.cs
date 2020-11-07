﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.DataTransferObjects.DtoAppUser;
using TaskTable.DataTransferObjects.DtoTask;
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
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public TaskOrderController(IAppUserService appUserService,
            ITaskService taskService, UserManager<AppUser> userManager,
            IFileService fileService,
            INotificationService notificationService,
            IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appUserService = appUserService;
            _taskService = taskService;
            _fileService = fileService;
            _notificationService = notificationService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "taskorder";
            var taskEntityList = _taskService.GetAllTasksWithAllProperties();
            var models = _mapper.Map<List<TaskListDto>>(taskEntityList);
            
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
           
            var appUserListModel = _mapper.Map<List<AppUserListDto>>(kullaniciEntities);
         
            ViewBag.Kullanicilar = appUserListModel;
            TaskListDto model = _mapper.Map<TaskListDto>(entity);
            return View(model);
        }
        [HttpGet]
        public IActionResult AssignTaskToUser(TaskAssignUserDto model)
        {
            TempData["active"] = "taskorder";
            
            var user = _userManager.Users.FirstOrDefault(a => a.Id == model.AppUserId);
            var taskEntity = _taskService.GetTaskWithUrgencyProperty(model.TaskId);
            
            AppUserListDto userListDto = _mapper.Map<AppUserListDto>(user);
            var taskListDto = _mapper.Map<TaskListDto>(taskEntity);
            
            TaskAssignUserListDto taskUserViewModel = new TaskAssignUserListDto();
            taskUserViewModel.AppUser = userListDto;
            taskUserViewModel.Task = taskListDto;
            
            return View(taskUserViewModel);
        }
        [HttpPost]
        public IActionResult AssignTaskOnUser(TaskAssignUserDto model)
        {
            var taskEntity = _taskService.Get(model.TaskId);
            taskEntity.AppUserId = model.AppUserId;
            _taskService.Update(taskEntity);

            _notificationService.Add(new NotificationEntity
            {
                AppUserId = model.AppUserId,
                Description = $"{taskEntity.Name} adlı iş için görevlendirildiniz."
            });
            return RedirectToAction("Index");
        }
        public IActionResult GiveDetail(int id)
        {
            TempData["active"] = "taskorder";
            var result = _taskService.GetTaskWithReportProperty(id);
            TaskListDto model = _mapper.Map<TaskListDto>(result);
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
