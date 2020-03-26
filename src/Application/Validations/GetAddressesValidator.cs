using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Mediators.PersonOperations.GetAddressesByPerson;
using Application.Notifications;

namespace Application.Validations
{
    public class GetAddressesValidator: AbstractValidator<GetAddressesRequest>
    {
        private readonly IClientDbContext _context;
       public GetAddressesValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.PersonId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("PersonId is required")
            .MustAsync(async (personId, cancellationToken) =>
            {
                return await _context.Persons.AnyAsync(x => x.PersonId == personId);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"The PersonId was not found");
        }

    }
}
