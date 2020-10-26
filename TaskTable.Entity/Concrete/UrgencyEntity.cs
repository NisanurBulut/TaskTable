using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.Entity.Concrete
{
    public class UrgencyEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
