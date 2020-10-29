using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public List<AppUser> GetNotAdminAppUsers()
        {
            using (var context = new DatabaseContext())
            {
                // eager loading .Include(a => a.UrgencyId)
               return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                    (userResult, userRoleResult) => new
                    {
                        user = userResult,
                        userRole = userRoleResult
                    }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
                    (resultTable, resultRole) => new
                    {
                        user = resultTable.user,
                        userrole = resultTable.userRole,
                        roles = resultRole
                    }).Where(a => a.roles.Name != "Admin").Select(a => new AppUser
                    {
                        Id = a.user.Id,
                        Email = a.user.Email,
                        Name = a.user.Name,
                        Surname = a.user.Surname,
                        UserName = a.user.UserName,
                        Picture = a.user.Picture
                    }).ToList();
            }
        }
    }
}
