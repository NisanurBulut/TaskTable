using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.Entity.Concrete
{
    // int yazmazsam primary key default string olur
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
