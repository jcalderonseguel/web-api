using Flunt.Notifications;
using MediatR;
using Application.Notifications;
using System;

namespace Application.Mediators.PersonOperations.GetAddressesByPerson
{
    public class GetAddressesRequest :Notifiable,IRequest<EntityResult<GetAddressesResult>>
    {
        public GetAddressesRequest(Guid personId)
        {
            PersonId = personId;
        }
        public Guid PersonId { get; set; }
    
    }
}
