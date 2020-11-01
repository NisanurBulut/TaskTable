using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProfilController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfilController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            // oturum açmış kullanıcı bilgisi okunur
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = appUser.Id;
            model.Name = appUser.Name;
            model.Picture = appUser.Picture;
            model.Surname = appUser.Surname;
            return View(model);
        }
    }
}
