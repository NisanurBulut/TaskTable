using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Business.Interfaces;
using TaskTable.DataTransferObjects;
using TaskTable.Entity.Concrete;
using TaskTable.Web.BaseControllers;

namespace TaskTable.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        // dependency Injection
       
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        public HomeController(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            IMapper mapper):base(userManager)
        {
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);
               
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    } 
                    AddError(addRoleResult.Errors);
                }
                AddError(result.Errors);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                // username var mı gerçekten
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                }
                var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (signInResult.Succeeded)
                {
                    // kullanıcının rolü belirlenmeli ki gideceği yeri bilelim
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }  
                    return RedirectToAction("Index", "Home", new { area = "Member" });
                }
            }
            return View("Index", model);
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult StatusCode(int? Code)
        {
           if(Code==404)
            {
                ViewBag.Code = Code;
                ViewBag.Message = "Sayfa hatası";
            }
            return View();
        }
    }
}
