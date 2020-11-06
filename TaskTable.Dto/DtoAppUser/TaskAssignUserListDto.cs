using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.DataTransferObjects.DtoTask;

namespace TaskTable.DataTransferObjects.DtoAppUser
{
    public class TaskAssignUserListDto
    {
        public TaskListDto Task { get; set; }
        public AppUserListDto AppUser { get; set; }
    }
}