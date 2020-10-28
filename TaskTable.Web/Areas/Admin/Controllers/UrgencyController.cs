using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        public UrgencyController(IUrgencyService urgencyService)
        {
            _urgencyService = urgencyService;
        }
        public IActionResult Index()
        {
            TempData["active"] = "urgency";
            var results = _urgencyService.GetirHepsi();
            return View(results);
        }
        public IActionResult AddUrgency()
        {
            return View(new UrgencyAddViewModel());
        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Ekle(new UrgencyEntity
                {
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditUrgency(int id)
        {
            TempData["active"] = "urgency";
            var model = _urgencyService.Getir(id);
            var urgencyEditViewModel = new UrgencyEditViewModel()
            {
                Description = model.Description,
                Id = model.Id
            };
            return View(urgencyEditViewModel);
        }
        [HttpPost]
        public IActionResult EditUrgency(UrgencyEditViewModel model)
        {
            UrgencyEntity entity = new UrgencyEntity()
            {
                Description = model.Description,
                Id = model.Id
            };
            _urgencyService.Guncelle(entity);
            return View();
        }
    }
}
