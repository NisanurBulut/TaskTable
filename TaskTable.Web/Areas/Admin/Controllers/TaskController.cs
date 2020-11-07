using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskTable.Business.Interfaces;
using TaskTable.DataTransferObjects.DtoTask;
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
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IUrgencyService urgencyService, IMapper mapper)
        {
            _mapper = mapper;
            _taskService = taskService;
            _urgencyService = urgencyService;          
        }
        public IActionResult Index()
        {
            TempData["active"] = "task";
            var taskEntities = _taskService.GetNotFinishedTasks();
            // automapper kullanılarak düzeltilecek
            var models = _mapper.Map<List<TaskListDto>>(taskEntities);
            return View(models);
        }
        [HttpGet]
        public IActionResult AddTask()
        {
            TempData["active"] = "task";
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description");
            return View(new TaskAddDto());
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddDto model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<TaskEntity>(model);
                _taskService.Add(entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult EditTask(int id)
        {
            TempData["active"] = "task";
            var entity = _taskService.Get(id);
            TaskEditDto model = _mapper.Map<TaskEditDto>(entity);
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description", model.UrgencyId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTask(TaskEditDto model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(_mapper.Map<TaskEntity>(model));
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
