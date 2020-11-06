using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.DataTransferObjects.DtoAppUser
{
    public class TaskAssignUserDto
    {
        public int TaskId { get; set; }
        public int AppUserId { get; set; }
    }
}
