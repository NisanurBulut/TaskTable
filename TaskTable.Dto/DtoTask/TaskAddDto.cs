using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.DataTransferObjects.DtoTask
{
    public class TaskAddDto
    {
        //[Required(ErrorMessage = "Ad alanı boş geçilemez")]
        //[Range(1, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz.")]
        public string Ad { get; set; }
        public int UrgencyId { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
    }
}
