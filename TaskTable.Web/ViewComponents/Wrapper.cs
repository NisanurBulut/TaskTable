using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        // view component geriye task dönemez
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
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
            model.NotificationsCount = _notificationService.GetUnReadAll(user.Id).Count(); 
            var roles = _userManager.GetRolesAsync(user).Result;
            if (roles.Contains("Admin"))
            {
                // varsayılana dmine git
                return View(model);
            }
            return View("Member", model);
        }
    }
}
