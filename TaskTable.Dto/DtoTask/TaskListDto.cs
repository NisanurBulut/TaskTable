using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.DataTransferObjects.DtoTask
{
    public class TaskListDto
    {
        //[Range(1, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz.")]
        //[Required(ErrorMessage ="Ad alanı boş geçilemez.")]
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
        public int UrgencyId { get; set; }
        //public UrgencyEntity Urgency { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
