using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskTable.Business.Interfaces;
using TaskTable.DataTransferObjects.DtoUrgency;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["active"] = "urgency";
            var results = _urgencyService.GetAll();
            var models = _mapper.Map<List<UrgencyListDto>>(results);
            return View(models);
        }
        public IActionResult AddUrgency()
        {
            return View(new UrgencyAddDto());
        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Add(new UrgencyEntity
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
            var model = _mapper.Map<UrgencyEditDto>(_urgencyService.Get(id));
           
            return View(model);
        }
        [HttpPost]
        public IActionResult EditUrgency(UrgencyEditDto model)
        {
            UrgencyEntity entity = _mapper.Map<UrgencyEntity>(model);
            _urgencyService.Update(entity);
            return RedirectToAction("Index");
        }
    }
}
