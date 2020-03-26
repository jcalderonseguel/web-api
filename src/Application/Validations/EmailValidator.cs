using FluentValidation;
using Application.Common.Helpers;
using Domain.Entities;
using System;

namespace Application.Validations
{
    public class EmailValidator : AbstractValidator<Emails>
    {
        public EmailValidator()
        {
            RuleFor(x => x.EmailAddress)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("EmailAddress is required")
            .MaximumLength(320).WithMessage("EmailAddress must have to 320 letters")
            .Must((email) =>
            {
                return (email.Trim().Equals("")) ? true : CommonHelper.EmailFormat(email);
            }).WithMessage("Email format incorrect");

            RuleFor(x => x).Must((Email) =>
            {
                int result = DateTime.Compare(Convert.ToDateTime(Email.ValidFrom), Convert.ToDateTime(Email.ValidTo));
                return result < 0 || result == 0;
            }).WithMessage("ValidTo must be >= ValidFrom")
            .When(x => CommonHelper.DateFormat(x.ValidFrom.ToString()) && CommonHelper.DateFormat(x.ValidTo.ToString()));
        }
    }
}