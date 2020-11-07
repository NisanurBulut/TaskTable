using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Business.Interfaces;
using TaskTable.DataTransferObjects;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        // view component geriye task dönemez
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            AppUserListDto model = _mapper.Map<AppUserListDto>(user);
           
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
