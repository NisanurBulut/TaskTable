using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.DataTransferObjects.DtoAppUser
{
    public class AppUserSignInDto
    {
        //[Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        //[Display(Name = "Kullanıcı Adı")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Parola boş geçilemez")]
        //[Display(Name = "Parola")]
        //[Display(Name = "Beni Hatirla")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
