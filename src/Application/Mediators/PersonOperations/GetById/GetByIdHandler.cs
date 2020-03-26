using FluentValidation.Results;
using MediatR;
using System.Linq;
using Application.Notifications;
using Application.Validations;
using Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Entities;
using Application.Common.Interfaces;

namespace Application.Mediators.PersonOperations.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdRequest, EntityResult<object>>
    {
        private readonly IClientDbContext _context;
        private readonly IPersonDataRepository _personDataRepository;
        
        public GetByIdHandler(IPersonDataRepository personDataRepository, IClientDbContext context)
        {
            _personDataRepository = personDataRepository;
            _context = context;

        }

        public async Task<EntityResult<object>> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            GetPersonValidator validator = new GetPersonValidator(_context);
            ValidationResult result = await validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    request.AddNotification(item.PropertyName, item.ErrorMessage);
                }

                return new EntityResult<object>(request.Notifications, result.Errors.All(err => err.ErrorCode == ErrorCode.NotFound.ToString()) ? ErrorCode.NotFound : ErrorCode.BadRequest);
            }

            //sql: query siempre full
            Persons person = await _personDataRepository.GetByIdAsync(request.PersonId);

            if (person is null)
            {
                return new EntityResult<object>("The person was not found.", ErrorCode.NotFound);
            }

            if (request.TypeOfview == "full")
            {
                return new EntityResult<object>(new FullPersonDto
                {
                    PersonId = person.PersonId,
                    FirstName = person.NaturalPersons.FirstName,
                    LastNamePrefix = person.NaturalPersons.LastNamePrefix,
                    LastName = person.NaturalPersons.LastName,
                    FullName = person.NaturalPersons.FullName,
                    GenderId = person.NaturalPersons.Gender,
                    Description = person.NaturalPersons.GenderNavigation.Description,
                    PersonCategory = person.CategoryNavigation.Description,
                    Phones = person.Phones.Select(p => new PhonesDto
                    {
                        AreaCode = p.AreaCode,
                        PhoneNumber = p.PhoneNumber,
                        Extension = p.Extension
                    }),
                    Emails = person.Emails.Select(e => new EmailDto
                    {
                        EmailAddres = e.EmailAddress,
                        Validated = e.Validated
                    }),
                    BirthDate = person.NaturalPersons.BirthDate,
                    MaritalStatus = person.NaturalPersons.MaritalStatusNavigation.Description,
                    Nationality = person.NaturalPersons.NationalityNavigation.Nationality,
                    Documents = person.IdentificationsDocuments.Select(d => new DocumentTypesDto
                    {
                        DocumentNumber = d.DocumentNumber,
                        DocumentTypeDescription = d.IdentificationDocumentTypeNavigation.Description,
                        DocumentTypeCode = d.IdentificationDocumentTypeNavigation.Typecode
                    })
                });
            }
            else
            {
                return new EntityResult<object>(new ShortPersonDto
                {
                    PersonId = person.PersonId,
                    PersonCategory = person.Category,

                    Person = new NaturalPersonsDto { 
                        FirstName = person.NaturalPersons.FirstName,
                        LastNamePrefix = person.NaturalPersons.LastNamePrefix,
                        LastName = person.NaturalPersons.LastName,
                        FullName = person.NaturalPersons.FullName,
                        Gender = new GenderDto { 
                            Id = person.NaturalPersons.Gender,
                            Description = person.NaturalPersons.GenderNavigation.Description
                        }

                    },
                });
            }
        }
    }
}