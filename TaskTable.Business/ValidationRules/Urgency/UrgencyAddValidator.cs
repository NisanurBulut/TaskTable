using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataTransferObjects.DtoUrgency;

namespace TaskTable.Business.ValidationRules.Urgency
{
   public class UrgencyAddValidator:AbstractValidator<UrgencyAddDto>
    {
        public UrgencyAddValidator()
        {
            RuleFor(r => r.Description).NotNull().WithMessage("Açıklama alanı boş bırakılamaz.");
        }
    }
}
