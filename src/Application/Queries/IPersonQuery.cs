using Application.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPersonQuery
    {
        Task<IEnumerable<PersonDto>> GetAllAsync(string email,
            string phoneNumber,
            Guid? personId,
            int? genderId,
            string countryId,
            int? identificationDocumentTypeId,
            string documentNumber);

        Task<PersonRelationDto> GetAllInternalAsync(
           Guid? personId,
           int? roletype
          );
        Task<IEnumerable<AddressesDto>> GetAddressesByPerson(Guid? personId);
        Task<IEnumerable<PersonsDto>> GetIdByAllAsync(
            int? identificationDocumentTypeId,
            string documentNumber,
            int? genderId,
            string email,
            string phoneNumber,
            string alias);
    }
}