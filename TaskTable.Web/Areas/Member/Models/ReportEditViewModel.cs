﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.Areas.Member.Models
{
    public class ReportEditViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        public string Description { get; set; }
        [Display(Name = "Detay")]
        [Required(ErrorMessage = "Detay alanı boş bırakılamaz.")]
        public string Detail { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
    }
}