using Application.Queries;
using System.Collections.Generic;

namespace Application.Mediators.PersonOperations.GetAddressesByPerson
{
    public class GetAddressesResult
    {
        public IEnumerable<AddressesDto> Addresses { get; set; }
    }
}
