using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class NotificationEntity : ITablo
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
