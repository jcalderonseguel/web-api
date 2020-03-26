using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Notifications;
using Domain.Entities;
using System;

namespace Application.Validations
{
    public class RoleValidator : AbstractValidator<Roles>
    {
        private readonly IClientDbContext _context;

        public RoleValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.RoleType)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("RoleType is required")
            .MustAsync(async (roleType, cancellationToken) =>
            {
                return await _context.RolesTypes.AnyAsync(x => x.RoleTypeId == roleType);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"RoleType {x.RoleType} doesn´t exist");

            RuleFor(x => x).NotEmpty().Must((plan) =>
            {
                int result = DateTime.Compare(Convert.ToDateTime(plan.ValidFrom), Convert.ToDateTime(plan.ValidTo));
                return result < 0 || result == 0;
            }).WithMessage(x => "ValidFrom must be <= ValidTo")
           .When(x => CommonHelper.DateFormat(x.ValidFrom.ToString()) && CommonHelper.DateFormat(x.ValidTo.ToString()));
        }
    }
}