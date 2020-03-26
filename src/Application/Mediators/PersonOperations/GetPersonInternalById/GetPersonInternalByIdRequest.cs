using Flunt.Notifications;
using MediatR;
using Application.Notifications;
using Application.Queries;
using System;


namespace Application.Mediators.PersonOperations.GetPersonInternalById
{
    public class GetPersonInternalByIdRequest : Notifiable, IRequest<EntityResult<PersonRelationDto>>
    {
        public GetPersonInternalByIdRequest(Guid? personId, int? roletype)
        {
            PersonId = personId;
            RoleType = roletype;
        }

       
        public Guid? PersonId { get; set; }
        public int? RoleType { get; set; }

      
    }
}