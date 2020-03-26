using Flunt.Notifications;
using MediatR;
using Application.Notifications;
using System;

namespace Application.Mediators.PersonOperations.GetById
{
    public class GetByIdRequest : Notifiable, IRequest<EntityResult<object>>
    {
        public GetByIdRequest(Guid personId, string typeOfView)
        {
            TypeOfview = typeOfView;
            PersonId = personId;
        }

        public string TypeOfview { get; set; }
        public Guid PersonId { get; set; }

     
    }
}