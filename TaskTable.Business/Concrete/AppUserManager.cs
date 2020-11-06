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
        public List<AppUser> GetNotAdminAppUsers(out int totalPage, string searchKey, int activePage = 1)
        {
            return _appUserRepository.GetNotAdminAppUsers(out totalPage, searchKey, activePage);
        }

        public List<GraphView> GetTopFiveUsersWithMostTaks()
        {
            return _appUserRepository.GetTopFiveUsersWithMostTaks();
        }

        public List<GraphView> GetWorkingUsersWithMostTaks()
        {
            return _appUserRepository.GetWorkingUsersWithMostTaks();
        }
    }
}
