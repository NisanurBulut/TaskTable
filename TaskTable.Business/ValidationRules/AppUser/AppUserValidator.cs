using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.DataTransferObjects.DtoAppUser;

namespace TaskTable.Business.ValidationRules.AppUser
{
    public class AppUserValidator : AbstractValidator<AppUserDto>
    {
        // Display ve compare fluent validasyon ile kullanılamaz.

        public AppUserValidator()
        {
            RuleFor(a => a.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(a => a.Name).NotNull().WithMessage("Ad boş geçilemez");
            RuleFor(a => a.Surname).NotNull().WithMessage("Soyadı boş geçilemez");
            RuleFor(a => a.Password).NotNull().WithMessage("Parola boş geçilemez");
            RuleFor(a => a.ConfirmPassword).NotNull().WithMessage("Parola onay alanı boş geçilemez");
            RuleFor(a => a.ConfirmPassword).Equal(a => a.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(a => a.Email).NotNull().WithMessage("Eposta boş geçilemez");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Geçersiz eposta adresi");
        }
    }
}
