using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.DataTransferObjects
{
    // sonradan düzeltilecek yanlış bir yöntem
    public class AppUserDto
    {
       
        public string UserName { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
    }
}
