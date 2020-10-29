using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.Interfaces;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        public AppUserManager(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        public List<AppUser> GetNotAdminAppUsers()
        {
            return _appUserRepository.GetNotAdminAppUsers();
        }
        public List<AppUser> GetNotAdminAppUsers(string searchKey, int activePage)
        {
            return _appUserRepository.GetNotAdminAppUsers(searchKey, activePage);
        }
    }
}
