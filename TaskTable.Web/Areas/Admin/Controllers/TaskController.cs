using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Admin.Controllers
{

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
            var taskentities = _taskService.GetirTamamlanmayanGorevler();
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
            ViewBag.Urgencies = new SelectList(_urgencyService.GetirHepsi(), "Id", "Description");
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Ekle(new TaskEntity
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
            var entity = _taskService.Getir(id);
            TaskEditViewModel model = new TaskEditViewModel()
            {
                Id = entity.Id,
                Aciklama = entity.Aciklama,
                Ad = entity.Ad,
                UrgencyId = entity.UrgencyId
            };
            ViewBag.Urgencies = new SelectList(_urgencyService.GetirHepsi(), "Id", "Description", model.UrgencyId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTask(TaskEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Guncelle(new TaskEntity
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
    }
}
