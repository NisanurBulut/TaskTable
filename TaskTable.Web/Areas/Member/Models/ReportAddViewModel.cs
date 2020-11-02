using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Web.Areas.Member.Models
{
    public class ReportAddViewModel
    {
        [Display(Name ="Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        public string Description { get; set; }
        [Display(Name = "Detay")]
        [Required(ErrorMessage = "Detay alanı boş bırakılamaz.")]
        public string Detail { get; set; }
        public int TaskId { get; set; }
    }
}
