using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Mediators.PersonOperations.Insert;
using Application.Notifications;

namespace Application.Validations
{
    public class PersonValidator : AbstractValidator<InsertPersonRequest>
    {
        private readonly IClientDbContext _context;

        public PersonValidator(IClientDbContext context)
        {
            _context = context;

            RuleFor(x => x.PersonNumber).MustAsync(async (personNumber, cancellationToken) =>
            {
                return !await _context.Persons.AnyAsync(x => x.PersonNumber == personNumber, cancellationToken);
            })
            .WithErrorCode(ErrorCode.NotFound.ToString())
           .When(x => x.PersonNumber != 0).WithMessage(x => $"Person Number:{x.PersonNumber} exists.");

            RuleFor(x => x.Category)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Category).MustAsync(async (category, cancellationToken) =>
            {
                return await _context.Categories.AnyAsync(x => x.CategoryId == category, cancellationToken);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"CategoryId:{x.Category} doesn't exist");

            RuleFor(x => x.Status)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Status is required")
            .MustAsync(async (status, cancellationToken) =>
            {
                return await _context.ClientsStatus.AnyAsync(x => x.ClientStatusId == status, cancellationToken);
            }).WithErrorCode(ErrorCode.NotFound.ToString())
            .WithMessage(x => $"ClientStatus:{x.Status} doesn't exist");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address must not be empty");

            RuleFor(x => x.IdentificationDocument).NotEmpty().WithMessage("IdentificationDocument must not be empty");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email must not be empty");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone must not be empty");

            RuleFor(x => x.NaturalPerson).NotEmpty().WithMessage("Natural person must not be empty ");

            RuleFor(x => x.Attachment).NotEmpty().WithMessage("Attachment must not be empty");

            RuleFor(x => x.NaturalPerson).SetValidator(new NaturalPersonValidator(context));
            RuleForEach(x => x.Address).NotNull().SetValidator(new AddressValidator(context));
            RuleForEach(x => x.IdentificationDocument).SetValidator(new IdentificationDocumentValidator(_context));
            RuleForEach(x => x.Email).NotNull().SetValidator(new EmailValidator());
            RuleForEach(x => x.Phone).NotNull().SetValidator(new PhoneValidator(context));
            RuleForEach(x => x.Income).SetValidator(new IncomeValidator(context));
            RuleForEach(x => x.Rol).SetValidator(new RoleValidator(context));
            RuleForEach(x => x.Attachment).SetValidator(new AttachmentValidator(context));
        }
    }
}