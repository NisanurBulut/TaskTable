using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Member.Controllers
{
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
           var results= _urgencyService.GetAllUrgency();
            return View(results);
        }
        public IActionResult AddUrgency()
        {
           
            return View(new UrgencyAddViewModel());
        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddViewModel model)
        {
            if(ModelState.IsValid)
            {
                _urgencyService.AddUrgency(new UrgencyEntity
                {
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
