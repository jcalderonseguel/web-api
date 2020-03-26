using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Notifications;
using Domain.Entities;
using System;

namespace Application.Validations
{
    public class NaturalPersonValidator : AbstractValidator<NaturalPersons>
    {
        private readonly IClientDbContext _context;

        public NaturalPersonValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .MaximumLength(100).WithMessage("FirstName must have to 100 letters")
            .NotEmpty().WithMessage("FirstName is required")
            .Must((firstName) =>
            {
                return (firstName.Trim().Equals("")) ? true : CommonHelper.OnlyLetters(firstName);
            }).WithMessage("FirstName must only contain letters");

            RuleFor(x => x.LastName)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEmpty().WithMessage("LastName is required")
           .MaximumLength(100).WithMessage("LastName must have to 100 letters")
           .Must((lastName) =>
            {
                return (lastName.Trim().Equals("")) ? true : CommonHelper.OnlyLetters(lastName);
            }).WithMessage("LastName must only contain letters");

            RuleFor(x => x.LastNamePrefix).NotNull().Must((lastNamePrefix) =>
            {
                return (lastNamePrefix.Trim().Equals("")) ? true : CommonHelper.OnlyLetters(lastNamePrefix);
            }).WithMessage("LastNamePrefix must only contain letters")
             .When(x => !string.IsNullOrWhiteSpace(x.LastNamePrefix));

            RuleFor(x => x.LastNamePrefix).MaximumLength(50).WithMessage("LastNamePrefix must have to 50 letters")
            .When(x => !string.IsNullOrWhiteSpace(x.LastNamePrefix));

            RuleFor(x => x.FullName)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("FullName is required")
            .MaximumLength(255).WithMessage("FullName must have to 255 letters")
            .Must((fullName) =>
            {
                return CommonHelper.OnlyLetters(fullName);
            }).WithMessage("FullName must only contain letters");

            RuleFor(x => x.Gender)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Gender is required")
            .MustAsync(async (gender, cancellationToken) =>
            {
                return await _context.Genders.AnyAsync(x => x.GenderId == gender);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"Gender:{x.Gender} doesn´t exist");

            RuleFor(x => x.MaritalStatus)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("MaritalStatus is required")
            .MustAsync(async (maritalStatus, cancellationToken) =>
            {
                return await _context.MaritalStatus.AnyAsync(x => x.MaritalStatusId == maritalStatus);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
           .WithMessage(x => $"MaritalStatus:{x.MaritalStatus} doesn´t exist")
            .When(x => x.MaritalStatus != null && x.MaritalStatus != 0);

            RuleFor(x => x.Nationality)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Nationality is required")
            .MaximumLength(3).WithMessage("Nationality must have to 3 letters")
            .MustAsync(async (nationality, cancellationToken) =>
            {
                return await _context.Countries.AnyAsync(x => x.CountryIsoCode == nationality);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"Nationality (country):{x.Nationality} doesn´t exist");

            RuleFor(x => x).Must((naturalPerson) =>
            {
                int result = DateTime.Compare(Convert.ToDateTime(naturalPerson.BirthDate), Convert.ToDateTime(naturalPerson.DateOfDeath));
                return result < 0 || result == 0;
            }).WithMessage("DateOfDeath must be >= BirthDate")
            .When(x => CommonHelper.DateFormat(x.BirthDate.ToString()) && CommonHelper.DateFormat(x.DateOfDeath.ToString()));
        }
    }
}