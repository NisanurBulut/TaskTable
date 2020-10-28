using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.Areas.Admin.Models
{
    public class TaskListViewModel
    {
        [Required(ErrorMessage ="Ad alanı boş geçilemez.")]
        public string Ad { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz.")]
        public int UrgencyId { get; set; }
        public UrgencyEntity Urgency { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
