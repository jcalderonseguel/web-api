using FluentValidation.Results;
using Flunt.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Notifications;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.IdDocumentOperations.Queries
{
    public class GetIdDocumentTypeByCountryQuery : Notifiable, IRequest<EntityResult<IdentificationDocumentVm>>
    {
        public string CountryId { get; set; }

        public GetIdDocumentTypeByCountryQuery(string CountryId)
        {
            this.CountryId = CountryId;
        }
    }

    public class GetIdDocumentTypeByCountryQueryHandler : IRequestHandler<GetIdDocumentTypeByCountryQuery, EntityResult<IdentificationDocumentVm>>
    {
        private readonly IClientDbContext _context;

        public GetIdDocumentTypeByCountryQueryHandler(IClientDbContext context)
        {
            _context = context;
        }

        public async Task<EntityResult<IdentificationDocumentVm>> Handle(GetIdDocumentTypeByCountryQuery request, CancellationToken cancellationToken)
        {
            GetIdDocumentTypeByCountryQueryValidator validator = new GetIdDocumentTypeByCountryQueryValidator(_context);
            ValidationResult result = await validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    request.AddNotification(item.PropertyName, item.ErrorMessage);
                }

                return new EntityResult<IdentificationDocumentVm>(request.Notifications, result.Errors.All(err => err.ErrorCode == ErrorCode.NotFound.ToString()) ? ErrorCode.NotFound : ErrorCode.BadRequest);
            }

            var list = await _context.DocumentsTypes
                .Where(x => x.IdentificationsDocuments.Any(x => x.PersonNavigation.NaturalPersons.NationalityNavigation.CountryIsoCode == request.CountryId))
                .Select(x => new IdentificationDocumentDto
                {
                    Id = x.DocumentTypeId,
                    Description = x.Description,
                    CountryId = _context.Countries.Where(x => x.CountryIsoCode == request.CountryId).FirstOrDefault().CountryIsoCode,
                    CountryName = _context.Countries.Where(x => x.CountryIsoCode == request.CountryId).FirstOrDefault().Description
                })
             .ToListAsync();

            return new EntityResult<IdentificationDocumentVm>(new IdentificationDocumentVm { idDocumentTypeList = list });
        }
    }
}