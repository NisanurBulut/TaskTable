using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }
            var userRole = await userManager.FindByNameAsync("nisanur");
            if (userRole == null)
            {
                var user = new AppUser { Name = "nisanur", Surname = "bulut", UserName = "nisanurbulut" };
                await userManager.CreateAsync(user, "1");
                await userManager.AddToRoleAsync(user,"Admin");
            }
        }
    }
}
