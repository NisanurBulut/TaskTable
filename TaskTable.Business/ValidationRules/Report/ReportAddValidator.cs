using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataTransferObjects.DtoReport;

namespace TaskTable.Business.ValidationRules.Report
{
   public class ReportAddValidator: AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(a => a.Description).NotNull().WithMessage("Açıklama alanı boş bırakılamaz.");
            RuleFor(a => a.Detail).NotNull().WithMessage("Detay alanı boş bırakılamaz.");
        }
    }
}
