using System.Collections.Generic;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface IAppUserRepository:IBaseRepository<AppUser>
    {
        List<AppUser> GetNotAdminAppUsers();
        List<AppUser> GetNotAdminAppUsers(string searchKey, int activePage = 1);
    }
}
