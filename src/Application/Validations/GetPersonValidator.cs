using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Mediators.PersonOperations.GetById;
using Application.Notifications;

namespace Application.Validations
{
    public class GetPersonValidator : AbstractValidator<GetByIdRequest>
    {
        private readonly IClientDbContext _context;
        public GetPersonValidator(IClientDbContext context)
        {
           
            _context = context;

            RuleFor(x => x.PersonId)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty().WithMessage("PersonId is required")
             .MustAsync(async (personId, cancellationToken) =>
             {
                 return await _context.Persons.AnyAsync(x => x.PersonId == personId);
             }).WithErrorCode(ErrorCode.NotFound.ToString())
             .WithMessage(x => $"Person :{x.PersonId} doesn´t exist");
        }
    }
}