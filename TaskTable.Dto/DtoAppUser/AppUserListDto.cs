using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.DataTransferObjects.DtoAppUser
{
   public class AppUserListDto
    {
        /*
          [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz")]
        [Display(Name = "Fotoğraf")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Geçersiz eposta adresi")]
        [Required(ErrorMessage = "Eposta boş geçilemez")]
        [Display(Name = "Eposta")]
         */
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
       
        public string Email { get; set; }
        public int NotificationsCount { get; set; }
    }
}
