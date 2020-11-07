using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataTransferObjects;

namespace TaskTable.Business.ValidationRules
{
   public class UrgencyEditValidator:AbstractValidator<UrgencyEditDto>
    {
        public UrgencyEditValidator()
        {
            RuleFor(r => r.Description).NotNull().WithMessage("Açıklama alanı boş bırakılamaz.");
        }
    }
}
