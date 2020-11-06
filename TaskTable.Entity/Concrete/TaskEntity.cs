using System;
using System.Collections.Generic;
using TaskTable.Entity.Interfaces;
namespace TaskTable.Entity.Concrete
{
    public class TaskEntity :BaseEntity, ITablo
    {
        public string Name { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        // görev oluşturulurken kullanıcı atama zorlaması olmaması için nullable olmalı
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        // nullable olmadıı için zorunlu alan
        public int UrgencyId { get; set; }
        public UrgencyEntity Urgency { get; set; }
        public List<ReportEntity> Reports { get; set; }
    }
}
