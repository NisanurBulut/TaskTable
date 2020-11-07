using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataTransferObjects.DtoTask;

namespace TaskTable.Business.ValidationRules.Task
{
    public class TaskAddValidator: AbstractValidator<TaskAddDto>
    {
        public TaskAddValidator()
        {
            RuleFor(a => a.Description).NotNull().WithMessage("Açıklama alanı boş bırakılamaz");
            RuleFor(a => a.Name).NotNull().WithMessage("Ad alanı boş bırakılamaz");
            RuleFor(a => a.UrgencyId).NotNull().WithMessage("Aciliyet alanı boş bırakılamaz");
            RuleFor(a => a.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu belirtiniz.");
        }
    }
}
