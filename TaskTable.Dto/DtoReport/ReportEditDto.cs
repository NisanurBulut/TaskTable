using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataTransferObjects
{
    public class ReportEditDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
    }
}
