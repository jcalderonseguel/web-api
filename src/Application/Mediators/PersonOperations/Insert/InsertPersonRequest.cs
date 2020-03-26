using Flunt.Notifications;
using MediatR;
using Application.Notifications;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.PersonOperations.Insert
{
    public class InsertPersonRequest : Notifiable, IRequest<EntityResult<PersonCreatedDto>>
    {
        public long PersonNumber { get; set; }
        public long Transaction { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }
        public NaturalPersons NaturalPerson { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Attachments> Attachment { get; set; }
        public ICollection<Emails> Email { get; set; }
        public ICollection<IdentificationsDocuments> IdentificationDocument { get; set; }
        public ICollection<Phones> Phone { get; set; }
        public ICollection<Incomes> Income { get; set; }
        public ICollection<Roles> Rol { get; set; }
    }
}
