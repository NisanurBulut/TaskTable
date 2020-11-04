﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        /*
         İlgili kullanıcının rapor sayısı
         İlgili kullanıcının bildirim sayısı
         İlgili kullanıcının görev sayısı
         */
        private readonly IReportService _reportService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITaskService _taskService;
        public HomeController(IReportService reportService, 
            UserManager<AppUser> userManager, ITaskService taskService)
        {
            _userManager = userManager;
            _reportService = reportService;
            _taskService = taskService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ReportCount = _reportService.GetReportsCountWithAppUserIdProperty(user.Id);
            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCountWithAppUserIdProperty(user.Id);
            TempData["active"] = "home";
            return View();
        }
    }
}
