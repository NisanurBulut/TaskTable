using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.DataTransferObjects.DtoTask;
using TaskTable.Entity.Concrete;
using TaskTable.Web.BaseControllers;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskController : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public TaskController(IAppUserService appUserService,
            ITaskService taskService, 
            UserManager<AppUser> userManager, 
            IFileService fileService, 
            IReportService reportService,
            IMapper mapper):base(userManager)
        {
            _appUserService = appUserService;
            _taskService = taskService;
            _fileService = fileService;
            _reportService = reportService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["active"] = "task";
            var user = await GetOnlineUser();
            int totalPage = 0;
            var taskEntityList = _taskService.GetAllCompleteTasksWithAllProperties(out totalPage, user.Id, activePage);
            var models = _mapper.Map<List<TaskListDto>>(taskEntityList);

            ViewBag.TotalPage = models.Count;
            ViewBag.ActivePage = activePage;
            return View(models);
        }

    }
}
