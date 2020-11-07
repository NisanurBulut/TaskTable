using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataTransferObjects
{
    public class TaskListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UrgencyId { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }
        public UrgencyEntity Urgency { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ReportEntity> Reports { get; set; }
        public AppUser AppUser { get; set; }
    }
}
