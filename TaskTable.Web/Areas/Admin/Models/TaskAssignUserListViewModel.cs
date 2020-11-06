using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Web.Areas.Admin.Models;

namespace TaskTable.Web.Areas.Admin.Models
{
    public class TaskAssignUserListViewModel
    {
        public TaskListViewModel Task { get; set; }
        public AppUserListViewModel AppUser { get; set; }
    }
}