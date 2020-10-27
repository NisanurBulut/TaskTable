using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;

namespace TaskTable.Web.Areas.Admin.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "task";
            return View(_taskService.GetirHepsi());
        }
    }
}
