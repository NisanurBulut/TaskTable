using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.Areas.Admin.Models
{
    public class AppUserListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz")]
        public string Surname { get; set; }
        [Display(Name = "Fotoğraf")]
        public string Picture { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Geçersiz eposta adresi")]
        [Required(ErrorMessage = "Eposta boş geçilemez")]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
        public int NotificationsCount { get; set; }
    }
}
