using Application.Common.Helpers;
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediators.UserOperations.Create
{
    internal class UserValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IClientDbContext _context;

        public UserValidator(IClientDbContext context)
        {
            _context = context;
            RuleFor(x => x.FullName).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Email)
                .NotEmpty().DependentRules(() =>
                {
                    RuleFor(x => x.Email)
                .MustAsync(async (email, cancellationToken) =>
                {
                    return !(await _context.Users.AnyAsync(x => x.Email == email));
                })
            .WithMessage(x => $"Email:{x.Email} exists")
                .Must((email) =>
                {
                    return (email.Trim().Equals("")) ? true : CommonHelper.EmailFormat(email);
                }).WithMessage("Email format incorrect")
                .MaximumLength(250);
                });

            RuleFor(x => x.Password).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(125);
        }
    }
}