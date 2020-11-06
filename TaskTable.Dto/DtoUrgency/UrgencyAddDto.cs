using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.DataTransferObjects.DtoUrgency
{
    public class UrgencyAddDto
    {
        /*
        [Display(Name = "Tanım")]
        [Required(ErrorMessage ="Tanım alanı boş bırakılamaz.")]
         */
        public string Description { get; set; }
    }
}
