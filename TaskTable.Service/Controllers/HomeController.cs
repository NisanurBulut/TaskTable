using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TaskTable.Service.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PageError(int code)
        {
            return View();
        }
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =
               HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Path = exceptionHandlerPathFeature.Path;
            ViewBag.Message = exceptionHandlerPathFeature.Error.Message;
            return View();
        }
    }
}
