using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Web.Areas.Admin.Models
{
    public class UrgencyEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tanım")]
        [Required(ErrorMessage ="Tanım alanı boş bırakılamaz.")]
        public string Description { get; set; }
    }
}
