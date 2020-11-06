using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataTransferObjects.DtoAppUser;

namespace TaskTable.Business.ValidationRules.AppUser
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(a => a.Password).NotNull().WithMessage("Parola boş geçilemez");
            RuleFor(a => a.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez");
        }
    }
}
