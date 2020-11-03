using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    // int yazmazsam primary key default string olur
    public class AppUser : IdentityUser<int>, ITablo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "default-user-icon.png";
        public List<TaskEntity> Tasks { get; set; }
        public List<NotificationEntity> Notifications { get; set; }
    }
}
