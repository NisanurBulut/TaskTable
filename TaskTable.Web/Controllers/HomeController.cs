using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;

namespace TaskTable.Web.Controllers
{
    public class HomeController : Controller
    {
        // dependency Injection
        ITaskService _taskServ;
        public HomeController(ITaskService taskService)
        {
            _taskServ = taskService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
