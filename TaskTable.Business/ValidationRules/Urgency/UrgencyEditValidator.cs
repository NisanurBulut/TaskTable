using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataTransferObjects.DtoUrgency;

namespace TaskTable.Business.ValidationRules.Urgency
{
   public class UrgencyEditValidator:AbstractValidator<UrgencyEditDto>
    {
        public UrgencyEditValidator()
        {
            RuleFor(r => r.Description).NotNull().WithMessage("Açıklama alanı boş bırakılamaz.");
        }
    }
}
