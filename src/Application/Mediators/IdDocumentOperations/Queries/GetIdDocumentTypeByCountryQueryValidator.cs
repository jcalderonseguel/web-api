using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Notifications;

namespace Application.Mediators.IdDocumentOperations.Queries
{
    public class GetIdDocumentTypeByCountryQueryValidator : AbstractValidator<GetIdDocumentTypeByCountryQuery>
    {
        private readonly IClientDbContext _context;

        public GetIdDocumentTypeByCountryQueryValidator(IClientDbContext context)
        {
            _context = context;
            RuleFor(x => x.CountryId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("CountryId is required")
            .MustAsync(async (countryId, cancellation) =>
            {
                return await _context.Countries.AnyAsync(x => x.CountryIsoCode == countryId, cancellation);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"CountryId: {x.CountryId} does not exists.");
        }
    }
}