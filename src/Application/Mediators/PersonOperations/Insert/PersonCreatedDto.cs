using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.PersonOperations.Insert
{
    public class PersonCreatedDto : INotification
    {
        public Guid PersonId { get; set; }
    }
}
