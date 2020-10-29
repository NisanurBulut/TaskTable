using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUrgencyService _urgencyService;
        
        public TaskController(ITaskService taskService, IUrgencyService urgencyService)
        {
            _taskService = taskService;
            _urgencyService = urgencyService;          
        }
        public IActionResult Index()
        {
            TempData["active"] = "task";
            var taskentities = _taskService.GetNotFinishedTasks();
            var results = new List<TaskListViewModel>();
            // automapper kullanılarak düzeltilecek
            foreach (var item in taskentities)
            {
                var model = new TaskListViewModel
                {
                    Id = item.Id,
                    Aciklama = item.Aciklama,
                    UrgencyId = item.UrgencyId,
                    Urgency = item.Urgency,
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
            TempData["active"] = "task";
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description");
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Add(new TaskEntity
                {
                    Ad = model.Ad,
                    Aciklama = model.Aciklama,
                    UrgencyId = model.UrgencyId,

                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult EditTask(int id)
        {
            TempData["active"] = "task";
            var entity = _taskService.Get(id);
            TaskEditViewModel model = new TaskEditViewModel()
            {
                Id = entity.Id,
                Aciklama = entity.Aciklama,
                Ad = entity.Ad,
                UrgencyId = entity.UrgencyId
            };
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description", model.UrgencyId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTask(TaskEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(new TaskEntity
                {
                    Ad = model.Ad,
                    Aciklama = model.Aciklama,
                    UrgencyId = model.UrgencyId,
                    Id = model.Id
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(new TaskEntity() { Id = id });
            return Json(null);
        }
      
    }
}
