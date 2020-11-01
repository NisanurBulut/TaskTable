using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Web.Models
{
    // sonradan düzeltilecek yanlış bir yöntem
    public class AppUserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Geçersiz eposta adresi")]
        [Required(ErrorMessage = "Eposta boş geçilemez")]       
        [Display(Name = "Eposta")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola boş geçilemez")]
        [Display(Name = "Parola")]        
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        [Display(Name = "Parolanızı tekrar giriniz")]        
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "İsim boş geçilemez")]
        [Display(Name = "İsim")]     
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Soyadı boş geçilemez")]
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }
    }
}
