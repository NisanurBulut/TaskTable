using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class UrgencyEntity : BaseEntity, ITablo
    {
        public string Description { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
