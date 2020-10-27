using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaskTable.Web.Areas.Admin.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            TempData["active"] = "task";
            return View();
        }
    }
}
