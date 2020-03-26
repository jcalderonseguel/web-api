using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Helpers;
using Application.Common.Interfaces;
using Application.Notifications;
using Domain.Entities;
using System;

namespace Application.Validations
{
    public class IdentificationDocumentValidator : AbstractValidator<IdentificationsDocuments>
    {
        private readonly IClientDbContext _context;

        public IdentificationDocumentValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.DocumentNumber)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("DocumentNumber is required")
            .MaximumLength(50).WithMessage("DocumentNumber must have to 50 letters")
            .MustAsync(async (documentNumber, cancellation) =>
            {
                return await _context.IdentificationsDocuments.AllAsync(x => x.DocumentNumber != documentNumber);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"DocumentNumber:{x.DocumentNumber} is exists.");

            RuleFor(x => x.IssuingAuthority).MaximumLength(50).WithMessage("IssuingAuthority must have to 50 letters")
            .When(x => !string.IsNullOrWhiteSpace(x.IssuingAuthority));

            RuleFor(x => x.IdentificationDocumentType)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("DocumentType is required")
            .MustAsync(async (type, cancellationToken) =>
            {
                return await _context.DocumentsTypes.AnyAsync(x => x.DocumentTypeId == type);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"DocumentType:{x.IdentificationDocumentType} doen´t exist");

            RuleFor(x => x).Must((identificationDocument) =>
            {
                int result = DateTime.Compare(Convert.ToDateTime(identificationDocument.IssuingDate), Convert.ToDateTime(identificationDocument.ExpiryDate));
                return (result > 0) ? false : true;
            }).WithMessage("ExpireDate must be >= IssuingDate")
            .When(x => CommonHelper.DateFormat(x.IssuingDate.ToString()) && CommonHelper.DateFormat(x.ExpiryDate.ToString()));

            RuleFor(x => x).Must((identificationDocument) =>
            {
                int result = DateTime.Compare(Convert.ToDateTime(identificationDocument.ValidFrom), Convert.ToDateTime(identificationDocument.ValidTo));
                return result < 0 || result == 0;
            }).WithMessage("ValidTo must be >= ValidFrom")
            .When(x => CommonHelper.DateFormat(x.ValidFrom.ToString()) && CommonHelper.DateFormat(x.ValidTo.ToString()));
        }
    }
}