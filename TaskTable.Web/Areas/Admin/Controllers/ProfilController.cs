using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            TempData["active"] = "profile";
            // oturum açmış kullanıcı bilgisi okunur
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = appUser.Id;
            model.Name = appUser.Name;
            model.Email = appUser.Email;
            model.Picture = appUser.Picture;
            model.Surname = appUser.Surname;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == model.Id);
                if (picture != null)
                {
                    string picExtension = Path.GetExtension(picture.FileName);
                    string fileName = new Guid() + picExtension;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img" + fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await picture.CopyToAsync(stream);
                    }
                    appUser.Picture = fileName;
                }
                appUser.Name = model.Name;
                appUser.Surname = model.Surname;
                appUser.Email = model.Email;
                var result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işlemi başarıyla gerçekleşti.";
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
