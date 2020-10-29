using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;

namespace TaskTable.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        public TaskOrderController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "taskorder";
            var model = _appUserService.GetNotAdminAppUsers();
            return View();
        }
    }
}
