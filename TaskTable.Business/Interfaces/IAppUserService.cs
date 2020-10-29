using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetNotAdminAppUsers();
    }
}
