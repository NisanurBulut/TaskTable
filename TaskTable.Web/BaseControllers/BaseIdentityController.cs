using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.BaseControllers
{
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
      
        protected async Task<AppUser> GetOnlineUser()
        {
            return await _userManager.FindByNameAsync(User.Identity.Name);
        }
        protected void AddError(IEnumerable<IdentityError> Errors)
        {
            foreach (var error in Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
