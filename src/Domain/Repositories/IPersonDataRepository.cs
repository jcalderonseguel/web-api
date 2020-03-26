using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPersonDataRepository
    {
        Task InsertAsync(Persons personData);

        Task<Persons> GetPersonByDocumentNumber(int genderId, string countryId, int identificationDocumentTypeId, string documentNumber);

        IdentificationsDocuments GetDocumentNumber(Guid personId);

        DocumentsTypes GetIdentificationDocumentTypeById(long id);

        Roles GetRoleById(Guid personId, int roleType);

        Genders GetGenderById(int id);

        ValueTask<Persons> GetByIdAsync(Guid personId);
    }
}