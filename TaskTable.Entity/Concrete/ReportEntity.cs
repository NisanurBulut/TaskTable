﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class ReportEntity : BaseEntity, ITablo
    {
        public string Description { get; set; }
        public string Detail { get; set; }

        // bir task silinirse report ta silinmeli
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
    }
}
