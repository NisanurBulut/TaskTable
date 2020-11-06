using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.DataTransferObjects.DtoAppUser
{
    // sonradan düzeltilecek yanlış bir yöntem
    public class AppUserDto
    {
        //[Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        //[Display(Name = "Kullanıcı Adı")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage ="Geçersiz eposta adresi")]
        //[Required(ErrorMessage = "Eposta boş geçilemez")]       
        //[Display(Name = "Eposta")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Parola boş geçilemez")]
        //[Display(Name = "Parola")]        
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        //[Display(Name = "Parolanızı tekrar giriniz")]        
        //[Required(ErrorMessage = "İsim boş geçilemez")]
        //[Display(Name = "İsim")]     
        //[Required(ErrorMessage = "Soyadı boş geçilemez")]
        //[Display(Name = "Soyadı")]
        public string UserName { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
    }
}
