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
        public string Name { get; set; }
        public int UrgencyId { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }
        //public UrgencyEntity Urgency { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
