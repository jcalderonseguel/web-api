using Application.Queries;
using System.Collections.Generic;

namespace Application.Mediators.PersonOperations.Get

{
    public class GetIdResult
    {
        public IEnumerable<PersonsDto> Persons { get; set; }
    }
}