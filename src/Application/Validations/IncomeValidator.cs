using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Notifications;
using Domain.Entities;
using System;

namespace Application.Validations
{
    public class IncomeValidator : AbstractValidator<Incomes>
    {
        private readonly IClientDbContext _context;

        public IncomeValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.Company)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Company is required")
            .MaximumLength(100).WithMessage("Company must have to 100 letters");

            RuleFor(x => x.Currency)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Currency is required")
            .MaximumLength(3).WithMessage("Currency must have to 3 letters")
            .MustAsync(async (currency, cancellationToken) =>
            {
                return await _context.Currencies.AnyAsync(x => x.IsoCode == currency);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"Currency:{x.Currency} doesn´t exist");

            RuleFor(x => x.Periodicity)
            .MustAsync(async (periodicity, cancellationToken) =>
            {
                return await _context.Periodicity.AnyAsync(x => x.PeriodicityId == periodicity);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"periodicity:{x.Periodicity} doen´t exist")
            .When(x => x.Periodicity != null && x.Periodicity != 0);

            RuleFor(x => x.ValidFrom).NotEmpty().WithMessage("ValidFrom is required");

            RuleFor(x => x).Must((Income) =>
            {
                int result = DateTime.Compare(Convert.ToDateTime(Income.ValidFrom), Convert.ToDateTime(Income.ValidTo));
                return result < 0 || result == 0;
            }).WithMessage("ValidTo must be >= ValidFrom")
            .When(x => CommonHelper.DateFormat(x.ValidFrom.ToString()) && CommonHelper.DateFormat(x.ValidTo.ToString()));
        }
    }
}