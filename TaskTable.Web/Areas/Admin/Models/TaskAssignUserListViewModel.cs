using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Web.Areas.Admin.Models
{
    public class TaskAssignUserListViewModel
    {
        public TaskListViewModel Task { get; set; }
        public AppUserListViewModel AppUser { get; set; }
    }
}