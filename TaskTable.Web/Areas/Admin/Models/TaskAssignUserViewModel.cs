using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Web.Areas.Admin.Models
{
    public class TaskAssignUserViewModel
    {
        public int TaskId { get; set; }
        public int AppUserId { get; set; }
    }
}
