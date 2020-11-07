using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaskTable.Business.Interfaces;
using TaskTable.Web.StringInfo;

namespace TaskTable.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GraphController : Controller
    {
        /*
        -En çok görev tamamlamış 5 personel
        -En çok görev almış 5 personel
        *Group by
        */
        private readonly IAppUserService _appUserService;
        public GraphController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["active"] = TempDataInfo.Graph;
            return View();
        }
        public IActionResult GetTopFiveUsersWithMostTaks()
        {
           var TopFiveUsersWithMostTaks=  JsonConvert.SerializeObject(_appUserService.GetTopFiveUsersWithMostTaks());

            return Json(TopFiveUsersWithMostTaks);

        }
        public IActionResult GetWorkingUsersWithMostTaks()
        {
            var WorkingUsersWithMostTaks = JsonConvert.SerializeObject(_appUserService.GetWorkingUsersWithMostTaks());

            return Json(WorkingUsersWithMostTaks);

        }
    }
}
