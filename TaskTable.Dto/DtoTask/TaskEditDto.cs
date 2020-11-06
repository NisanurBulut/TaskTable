using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.DataTransferObjects.DtoTask
{
    public class TaskEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UrgencyId { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }
    }
}
