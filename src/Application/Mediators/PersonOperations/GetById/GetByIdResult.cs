using Application.Queries;
using System.Collections.Generic;

namespace Application.Mediators.PersonOperations.GetById

{
    public class GetByIdResult
    {
        public IEnumerable<ShortPersonDto> PersonsShort { get; set; }
        public IEnumerable<FullPersonDto> PersonsFull { get; set; }
    }
}