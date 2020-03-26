using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Notifications;
using Domain.Entities;

namespace Application.Validations
{
    public class AttachmentValidator : AbstractValidator<Attachments>
    {
        private readonly IClientDbContext _context;

        public AttachmentValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.AttachmentType)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("AttachmentType is required")
            .MustAsync(async (attachmentType, cancellationToken) =>
            {
                return await _context.AttachmentsTypes.AnyAsync(x => x.AttachmentTypeId == attachmentType);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"AttachmentType:{x.AttachmentType} doesn´t exist");

            RuleFor(x => x.FileName)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("FileName is required")
            .MaximumLength(50).WithMessage("FileName must have to 50 letters");

            RuleFor(x => x.Notes)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Notes is required")
            .MaximumLength(255).WithMessage("Notes must have to 255 letters");

            RuleFor(x => x.OwnerKey).MaximumLength(100).WithMessage("OwnerKey must have to 100 letters")
            .When(x => !string.IsNullOrWhiteSpace(x.OwnerKey));

            RuleFor(x => x.EncodedKey).MaximumLength(100).WithMessage("EncodedKey must have to 100 letters")
            .When(x => !string.IsNullOrWhiteSpace(x.EncodedKey));

            RuleFor(x => x.FileSize).NotEmpty().WithMessage("FileSize is required");

            RuleFor(x => x.Name)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name must have to 50 letters");

            RuleFor(x => x.Location)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(100).WithMessage("Name must have to 100 letters");
        }
    }
}