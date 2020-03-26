using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Notifications;
using Domain.Entities;
using System;

namespace Application.Validations
{
    public class PhoneValidator : AbstractValidator<Phones>
    {
        private readonly IClientDbContext _context;

        public PhoneValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.PhoneType)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("PhoneType is required")
            .MustAsync(async (phoneType, cancellationToken) =>
            {
                return await _context.PhonesTypes.AnyAsync(x => x.PhoneTypeId == phoneType);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"PhoneType:{x.PhoneType} doesn´t exist");

            RuleFor(x => x.CountryIsoCode)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("CountryIsoCode is required")
            .MaximumLength(3).WithMessage("CountryIsoCode must have to 3 letters")
            .MustAsync(async (countryIsoCode, cancellationToken) =>
            {
                return await _context.Countries.AnyAsync(x => x.CountryIsoCode == countryIsoCode);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"CountryIsoCode:{x.CountryIsoCode} doesn´t exist");

            RuleFor(x => x.AreaCode)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("AreaCode is required")
            .MaximumLength(10).WithMessage("AreaCode must have to 10 letters");

            RuleFor(x => x.PhoneNumber)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("PhoneNumber is required")
            .MaximumLength(30).WithMessage("PhoneNumber must have to 30 numbers")
            .Must((phoneNumber) =>
            {
                return CommonHelper.IsLong(phoneNumber);
            }).WithMessage("phoneNumber must be a number");

            RuleFor(x => x.Extension).MaximumLength(10).WithMessage("Extension must have to 10 letters")
            .When(x => !string.IsNullOrWhiteSpace(x.Extension));

            RuleFor(x => x).Must((Phone) =>
            {
                int result = DateTime.Compare(Convert.ToDateTime(Phone.ValidFrom), Convert.ToDateTime(Phone.ValidTo));
                return result < 0 || result == 0;
            }).WithMessage("ValidTo must be >= ValidFrom")
            .When(x => CommonHelper.DateFormat(x.ValidFrom.ToString()) && CommonHelper.DateFormat(x.ValidTo.ToString()));
        }
    }
}