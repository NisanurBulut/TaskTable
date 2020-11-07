using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskTable.DataTransferObjects.DtoAppUser;
using TaskTable.Entity.Concrete;
using TaskTable.Web.BaseControllers;

namespace TaskTable.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class ProfilController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        public ProfilController(UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "profile";
            // oturum açmış kullanıcı bilgisi okunur
            var appUser = await GetOnlineUser();
            AppUserListDto model = _mapper.Map<AppUserListDto>(appUser);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == model.Id);
                if (picture != null)
                {
                    string picExtension = Path.GetExtension(picture.FileName);
                    string fileName = Guid.NewGuid().ToString() + picExtension;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + fileName);
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
                AddError(result.Errors);
            }
            return View();
        }
    }
}
