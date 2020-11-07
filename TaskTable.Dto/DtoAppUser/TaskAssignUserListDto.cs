using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.DataTransferObjects;

namespace TaskTable.DataTransferObjects
{
    public class TaskAssignUserListDto
    {
        public TaskListDto Task { get; set; }
        public AppUserListDto AppUser { get; set; }
    }
}