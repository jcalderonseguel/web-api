using Application.Common.Helpers;
using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Mediators.UserOperations.Create
{
    internal class UserValidator : AbstractValidator<CreateUserCommand>
    {
        public UserValidator()
        {
            RuleFor(x => x.FullName).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must((email) =>
                {
                    return (email.Trim().Equals("")) ? true : CommonHelper.EmailFormat(email);
                }).WithMessage("Email format incorrect")
                .MaximumLength(250);

            RuleFor(x => x.Password).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(125);
        }
    }
}