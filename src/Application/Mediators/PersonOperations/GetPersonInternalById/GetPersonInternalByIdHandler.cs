using Flunt.Validations;
using MediatR;
using Application.Notifications;
using Application.Queries;
using Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.GetPersonInternalById
{
    public class GetPersonInternalByIdHandler : IRequestHandler<GetPersonInternalByIdRequest, EntityResult<PersonRelationDto>>
    {
        private readonly IPersonQuery _personQuery;

        public GetPersonInternalByIdHandler(IPersonQuery personQuery)
        {
            this._personQuery = personQuery;
        }

        public async Task<EntityResult<PersonRelationDto>> Handle(GetPersonInternalByIdRequest request, CancellationToken cancellationToken)
        {
            var person = await _personQuery.GetAllInternalAsync(request.PersonId, request.RoleType);
            
            request.AddNotifications(new Contract()
              .IsNotNull(person.AccountPerson, "person", $"Person was not found"));

            if (person != null)
                return new EntityResult<PersonRelationDto>(request.Notifications, person);
            else
                return new EntityResult<PersonRelationDto>(request.Notifications, ErrorCode.NotFound);

        }
    }
}