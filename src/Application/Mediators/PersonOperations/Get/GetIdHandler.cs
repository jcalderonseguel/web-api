using MediatR;
using Application.Notifications;
using Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.Get
{
    public class GetIdHandler : IRequestHandler<GetIdRequest, EntityResult<GetIdResult>>
    {
        private readonly IPersonQuery _personQuery;

        public GetIdHandler(IPersonQuery personQuery)
        {
            this._personQuery = personQuery;
        }

        public async Task<EntityResult<GetIdResult>> Handle(GetIdRequest request, CancellationToken cancellationToken)
        {
            var result = new EntityResult<GetIdResult>(new GetIdResult());

            if (request.Invalid)
            {
                result.AddNotifications(request.Notifications, ErrorCode.BadRequest);
                return result;
            }

            var persons = await _personQuery.GetIdByAllAsync(request.IdentificationDocumentTypeId,
                                                        request.DocumentNumber,
                                                        request.GenderId,
                                                        request.Email,
                                                        request.PhoneNumber,
                                                        request.Alias);

            if (!persons.Any())
            {
                request.AddNotification("Person", "Persons was not found");
                return new EntityResult<GetIdResult>(request.Notifications, ErrorCode.NotFound);
            }

            result.Entity.Persons = persons;
            return result;
        }
    }
}