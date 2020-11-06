using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.DataTransferObjects.DtoTask
{
    public class TaskEditDto
    {
        //[Required(ErrorMessage = "Ad alanı boş geçilemez")]
        //[Range(1, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz.")]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int UrgencyId { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
    }
}
