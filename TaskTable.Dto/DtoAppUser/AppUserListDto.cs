using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.DataTransferObjects
{
   public class AppUserListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
       
        public string Email { get; set; }
        public int NotificationsCount { get; set; }
    }
}
