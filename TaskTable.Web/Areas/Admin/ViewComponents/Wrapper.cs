using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Admin.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        // view component geriye task dönemez
        private readonly UserManager<AppUser> _userManager;
        public Wrapper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            AppUserListViewModel model = new AppUserListViewModel();
            model.Name = user.Name;
            model.Picture = user.Picture;
            model.Id = user.Id;
            model.Surname = user.Surname;
            model.Email = user.Email;
            return View(model);
        }
    }
}
