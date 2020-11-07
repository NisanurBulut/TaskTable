using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.DataTransferObjects
{
    public class TaskAddDto
    {
        public string Name { get; set; }
        public int UrgencyId { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }
    }
}
