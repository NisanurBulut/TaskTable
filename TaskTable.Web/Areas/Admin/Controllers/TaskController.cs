using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
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
            var taskentities = _taskService.GetirHepsi();
            var results = new List<TaskListViewModel>();
            // automapper kullanılarak düzeltilecek
            foreach (var item in taskentities)
            {
                var model = new TaskListViewModel
                {
                    Aciklama = item.Aciklama,
                    UrgencyId = item.UrgencyId,
                    OlusturulmaTarihi = item.OlusturulmaTarihi,
                    Ad = item.Ad,
                    Durum = item.Durum
                };
                results.Add(model);
            }
            return View(results);
        }
        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddViewModel model)
        {
            if(ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
