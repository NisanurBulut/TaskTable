using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskTable.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    // area kavramı yalnızca controllera özgüdür
    // viewcomponentlerde kullanılamaz
    // her view component'in bir default'ı olmalıdır.
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
