using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.DataTransferObjects.DtoReport
{
    public class ReportAddDto
    {
        //[Display(Name ="Açıklama")]
        //[Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        //[Display(Name = "Detay")]
        //[Required(ErrorMessage = "Detay alanı boş bırakılamaz.")]
        public string Description { get; set; }
        public string Detail { get; set; }
        public int TaskId { get; set; }
        //public TaskEntity Task { get; set; }
    }
}
