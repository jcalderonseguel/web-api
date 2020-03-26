using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Notifications;
using Domain.Entities;
using System;

namespace Application.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        private readonly IClientDbContext _context;

        public AddressValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.City).MustAsync(async (city, cancellationToken) =>
            {
                return await _context.Cities.AnyAsync(x => x.CityId == city);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
           .WithMessage(x => $"City:{x.City} doesn´t exist")
           .When(x => x.City != null && x.City != 0);

            RuleFor(x => x.AddressType)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("AddressType is required")
            .MustAsync(async (addressType, cancellationToken) =>
            {
                return await _context.AddressesTypes.AnyAsync(x => x.AddressTypeId == addressType);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"AddressType:{x.AddressType} doesn´t exist");

            RuleFor(x => x.StatusCodeAddress).MustAsync(async (statusCodeAddress, cancellationToken) =>
            {
                return await _context.StatusCodesAddresses.AnyAsync(x => x.StatusCodeAddressId == statusCodeAddress);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
          .WithMessage(x => $"StatusCodeAddress:{x.StatusCodeAddress} doesn´t exist")
          .When(x => x.StatusCodeAddress != null && x.StatusCodeAddress != 0);

            RuleFor(x => x.PostCode)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEmpty().WithMessage("PostCode is required")
           .MaximumLength(20).WithMessage("PostCode must have to 20 letters");

            RuleFor(x => x.StreetName).MaximumLength(100).WithMessage("StreetName must have to 100 letters")
            .When(x => !string.IsNullOrWhiteSpace(x.StreetName));

            RuleFor(x => x.BuildingNumber).MaximumLength(20).WithMessage("BuildingNumber must have to 20 letters")
           .When(x => !string.IsNullOrWhiteSpace(x.BuildingNumber));

            RuleFor(x => x.AddressLine).MaximumLength(100).WithMessage("AddressLine must have to 100 letters")
           .When(x => !string.IsNullOrWhiteSpace(x.AddressLine));

            RuleFor(x => x.PostOfficeBoxCode).MaximumLength(10).WithMessage("PostOfficeBoxCode must have to 10 letters")
           .When(x => !string.IsNullOrWhiteSpace(x.PostOfficeBoxCode));

            RuleFor(x => x.PoboxPostalCode).MaximumLength(10).WithMessage("PoboxPostalCode must have to 10 letters")
           .When(x => !string.IsNullOrWhiteSpace(x.PoboxPostalCode));

            RuleFor(x => x.Coname).MaximumLength(100).WithMessage("Coname must have to 100 letters")
          .When(x => !string.IsNullOrWhiteSpace(x.Coname));

            RuleFor(x => x.ValidFrom).NotEmpty().WithMessage("ValidFrom is required");

            RuleFor(x => x).Must((Address) =>
            {
                int result = DateTime.Compare(Convert.ToDateTime(Address.ValidFrom), Convert.ToDateTime(Address.ValidTo));
                return result < 0 || result == 0;
            }).WithMessage("ValidTo must be >= ValidFrom")
            .When(x => CommonHelper.DateFormat(x.ValidFrom.ToString()) && CommonHelper.DateFormat(x.ValidTo.ToString()));
        }
    }
}