using SqlKata.Compilers;
using SqlKata.Execution;
using SqlKata.Extensions;
using Application.Mediators.PersonOperations.ValidatePhoneNumber;
using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Queries
{
    public class PersonQuery : IPersonQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public PersonQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public Task<IEnumerable<PersonDto>> GetAllAsync(string email,
            string phoneNumber,
            Guid? personId,
            int? genderId,
            string countryId,
            int? identificationDocumentTypeId,
            string documentNumber)
        {
            var query = new QueryFactory(connection, sqlKataCompiler).Query("Persons as P")
                .Select($"P.{nameof(Persons.PersonNumber)}",
                        $"P.{nameof(Persons.Category)}",
                        $"R.{nameof(Roles.ValidTo)}")
                .ForSqlServer(q => q.SelectRaw("CONCAT(Np.FirstName + ' ', Np.LastName) as PersonName"))
                .LeftJoin("Emails", "Emails.Person", "P.PersonId", "=")
                .LeftJoin("Phones", "Phones.Person", "P.PersonId", "=")
                .LeftJoin("NaturalPersons as NP", "NP.Person", "P.PersonId", "=")
                .LeftJoin("IdentificationsDocuments as ID", "ID.Person", "P.PersonId", "=")
                .LeftJoin("DocumentsTypes as IDT", "ID.IdentificationDocumentType", "IDT.DocumentTypeId", "=")
                .LeftJoin("Roles as R", "P.PersonId", "R.Person", "=")
                .When(personId.HasValue, q => q.Where("P.PersonId", "=", personId))
                .When(!string.IsNullOrEmpty(email), q => q.Where("Emails.EmailAddress", "=", email))
                .When(!string.IsNullOrEmpty(phoneNumber), q => q.WhereRaw("CONCAT(Phones.CountryIsoCode, Phones.AreaCode, Phones.PhoneNumber) = ?", phoneNumber))
                .When(genderId.HasValue, q => q.Where("NP.Gender", "=", genderId))
                .When(!string.IsNullOrEmpty(countryId), q => q.Where("NP.Nationality", "=", countryId))
                .When(identificationDocumentTypeId.HasValue, q => q.Where("ID.IdentificationDocumentType", "=", identificationDocumentTypeId))
                .When(!string.IsNullOrEmpty(documentNumber), q => q.Where("ID.DocumentNumber", "=", documentNumber));

            return query.GetAsync<PersonDto>();
        }
        public async Task<PersonRelationDto> GetAllInternalAsync(
           Guid? personId,
           int? roletype
          )
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            PersonRelationDto PersonRelation = new PersonRelationDto();

            var query = await db.Query("Persons as P")
            .Select("P.PersonNumber",
                    "P.Category",
                    "P.PersonId",
                    "Np.FirstName",
                    "Np.LastNamePrefix",
                    "Np.LastName",
                    "Np.FullName",
                    "Np.BirthDate",
                    "Np.DateOfDeath",
                    "MS.Description AS MaritalStatus",
                    "Np.Nationality",
                    "Np.Gender",
                    "Rt.Description as RoleTypeDescription",
                    "R.ValidTo"
                    )
            .ForSqlServer(q => q.SelectRaw("CONCAT(Np.FirstName + ' ', Np.LastName) as PersonName"))
            .LeftJoin("Emails", "Emails.Person", "P.PersonId", "=")
            .LeftJoin("Phones", "Phones.Person", "P.PersonId", "=")
            .LeftJoin("NaturalPersons as NP", "NP.Person", "P.PersonId", "=")
            .LeftJoin("IdentificationsDocuments as ID", "ID.Person", "P.PersonId", "=")
            .LeftJoin("DocumentsTypes as IDT", "ID.IdentificationDocumentType", "IDT.DocumentTypeId", "=")
            .LeftJoin("Roles as R", "P.PersonId", "R.Person", "=")
            .LeftJoin("RolesTypes as Rt", "R.RoleType", "Rt.RoleTypeId", "=")
            .LeftJoin("MaritalStatus as MS","NP.MaritalStatus", "MS.MaritalStatusId", "=")
            .Where("P.PersonId", "=", personId)
            .Where("Rt.RoleTypeId", "=", roletype)
            .GetAsync();

           

            foreach (var item in query)
            {
              

                List<IdentificationDocumentsDto> IdentificationDocuments = new List<IdentificationDocumentsDto>();

                var identificationDocumentsQuery = await db.Query("NaturalPersons as NP")
                    .Select("DT.DocumentTypeId as DocumentTypeId")
                    .Select("DT.Description as Description")
                    .Select("ID.DocumentNumber as DocumentNumber")
                    .Select("C.CountryIsoCode as CountryIsoCode")
                    .Select("C.Description as CountryDescription")
                    .Select("C.CountryIsoNumb as CountryIsoNumb")
                    .Select("ID.IssuingDate as IssuingDate")
                    .Select("ID.IssuingAuthority as IssuingAuthority")
                    .Select("ID.ExpiryDate as ExpiryDate")
                    .Select("ID.ValidFrom as ValidFrom")
                    .Select("ID.ValidTo as ValidTo")
                    .Join("Countries as C", x => x.On("NP.Nationality", "C.CountryIsoCode"))
                    .Join("Persons as P", x => x.On("NP.Person", "P.PersonId"))
                    .Join("IdentificationsDocuments as ID", x => x.On("P.PersonId", "ID.Person"))
                    .Join("DocumentsTypes as DT", x => x.On("ID.IdentificationDocumentType", "DT.DocumentTypeId"))
                    .Where("P.PersonId",personId)
                    .GetAsync();

                int count = Enumerable.Count(identificationDocumentsQuery);

                if(count > 0)
                {
                    foreach (var identificationDocument in identificationDocumentsQuery)
                    {
                        IdentificationDocuments.Add(new IdentificationDocumentsDto 
                        {
                            DocumentNumber = identificationDocument.DocumentNumber,
                            IdentificationDocumentType = new IdentificationDocumentTypeDto 
                            { 
                                IdType = identificationDocument.DocumentTypeId,
                                Description = identificationDocument.Description,
                                Country = new CountryDto
                                {
                                    CountryId = identificationDocument.CountryIsoCode,
                                    CountryDescription = identificationDocument.CountryDescription,
                                    IsoCountryCode = identificationDocument.CountryIsoNumb
                                },
                            },
                            IssueDate = identificationDocument.IssuingDate,
                            IssueAuthority = identificationDocument.IssuingAuthority,
                            ExpiryDate = identificationDocument.ExpiryDate,
                            ValidFrom = identificationDocument.ValidFrom,
                            ValidTo = identificationDocument.ValidTo
                        });
                    }
                }

                PersonRelation = new PersonRelationDto
                {
                    RoleType = item.RoleTypeDescription,
                    AccountPerson = new AccountPersonDto
                    {
                        NaturalPerson = new NaturalPersonDto
                        {
                            PersonId = item.PersonId,
                            FirstName = item.FirstName,
                            LastNamePrefix = item.LastNamePrefix,
                            LastName = item.LastName,
                            FullName = item.FullName,
                            BirthDate = item.BirthDate,
                            DateOfDeath = item.DateOfDeath,
                            MaritalStatus = item.MaritalStatus,
                            Nationality = item.Nationality,
                            GenderId = item.Gender,
                            IdentificationDocuments = IdentificationDocuments,
                        }
                    },
                };
            }

            return PersonRelation;
        }
        public async Task<IEnumerable<PersonsDto>> GetIdByAllAsync(int? identificationDocumentTypeId,
            string documentNumber,
            int? genderId,
            string email,
            string phoneNumber,
            string alias)
        {
          
            var query = await new QueryFactory(connection, sqlKataCompiler).Query("Persons as P")
                .Select("P.PersonId",
                        "P.Category",
                        "NP.FirstName",
                        "NP.LastNamePrefix",
                        "NP.LastName",
                        "NP.FullName",
                        "GE.GenderId",
                        "GE.Description as Gender")
                .LeftJoin("Emails", "Emails.Person", "P.PersonId", "=")
                .LeftJoin("Phones", "Phones.Person", "P.PersonId", "=")
                .LeftJoin("NaturalPersons as NP", "NP.Person", "P.PersonId", "=")
                .LeftJoin("IdentificationsDocuments as ID", "ID.Person", "P.PersonId", "=")
                .LeftJoin("DocumentsTypes as IDT", "ID.IdentificationDocumentType", "IDT.DocumentTypeId", "=")
                .Join("Genders as GE", "GE.GenderId", "NP.Gender")
                .When(genderId.HasValue, q => q.Where("NP.Gender", "=", genderId))
                .When(identificationDocumentTypeId.HasValue, q => q.Where("ID.IdentificationDocumentType", "=", identificationDocumentTypeId))
                .When(!string.IsNullOrEmpty(documentNumber), q => q.Where("ID.DocumentNumber", "=", documentNumber))
                .When(!string.IsNullOrEmpty(email), q => q.Where("Emails.EmailAddress", "=", email))
                .When(!string.IsNullOrEmpty(phoneNumber), q => q.Where("Phones.PhoneNumber", "=", phoneNumber))
                .When(!string.IsNullOrEmpty(alias), q => q.Where("NP.Alias", "=", alias)).GetAsync();
            
            IList<PersonsDto> persons = new List<PersonsDto>();
            foreach (var p in query)
            {
                persons.Add(new PersonsDto
                {
                    PersonId = p.PersonId,
                    PersonCategory = p.Category,
                    Person = new NaturalPersonsDto
                    {
                        FirstName = p.FirstName,
                        LastNamePrefix = p.LastNamePrefix,
                        LastName = p.LastName,
                        FullName = p.FullName,
                        Gender = new GenderDto { 
                            Id = p.GenderId,
                            Description = p.Gender
                        }
                    }
                });

            }

            return persons;
        }

        public Task<ValidatePhoneNumberDto> GetPersonByPhoneNumberAsync(string countryCode, string areaCode, string phoneNumber)
        {
            var query = new QueryFactory(connection, sqlKataCompiler).Query("Persons")
                .Select("Persons.PersonNumber as PersonID")
                .Join("Phone", "Phone.PersonNumber", "Persons.PersonNumber", "=")
                .When(countryCode != null, q => q.Where("Phone.CountryCode", "=", countryCode))
                .When(areaCode != null, q => q.Where("Phone.AreaCode", "=", areaCode))
                .When(phoneNumber != null, q => q.Where("Phone.PhoneNumber", "=", phoneNumber));

            return query.FirstOrDefaultAsync<ValidatePhoneNumberDto>();
        }

        public Task<bool> PersonExistsAsync(long personId)
        {
            var query = new QueryFactory(connection, sqlKataCompiler).Query("Persons")
                .ForSqlServer(q => q.SelectRaw("Cast(Count(PersonNumber) as bit)"))
                .Where("Persons.PersonNumber", "=", personId);

            return query.FirstOrDefaultAsync<bool>();
        }

       public async Task<IEnumerable<AddressesDto>> GetAddressesByPerson(Guid? personId)
        {
            IList<AddressesDto> addresses = new List<AddressesDto>();

            var query = await new QueryFactory(connection, sqlKataCompiler).Query("Address")
                .Select("Address.PostCode",
                        "Address.Neighborhood",
                        "Address.StreetName",
                        "Address.BuildingNumber",
                        "Address.AddressLine",
                        "Address.Latitude",
                        "Address.Longitude",
                        "Cities.Description AS City",
                        "Address.StatusCodeAddress",
                        "Countries.Description AS Country",
                        "Regions.Description AS Region",
                        "AddressesTypes.Description as AddressesTypes")
                .Join("Persons", x => x.On("Address.Person", "Persons.PersonId"))
                .Join("AddressesTypes", x => x.On("Address.AddressType", "AddressesTypes.AddressTypeId"))
                .LeftJoin("Cities", x => x.On("Address.City", "Cities.CityId"))
                .LeftJoin("NaturalPersons", x => x.On("NaturalPersons.Person", "Persons.PersonId", "="))
                .LeftJoin("Countries", x => x.On("Countries.CountryIsoCode", "NaturalPersons.Nationality", "="))
                .LeftJoin("Regions", x => x.On("Regions.Country", "Countries.CountryIsoCode"))
                .Where("Persons.PersonId", personId)
                .GetAsync();

            foreach (var a in query)
            {
                addresses.Add(new AddressesDto
                {
                    AddressType = a.AddressesTypes,
                    Country = a.Country,
                    Region = a.Region,
                    City = a.City,
                    Neighborhood = a.Neighborhood,
                    PostCode = a.PostCode,
                    StreetName = a.StreetName,
                    BuildingNumber = a.BuildingNumber,
                    AddressLine = a.AddressLine,
                    Latitude = a.Latitude,
                    Longitude = a.Longitude,
                    AddressCodeStatus = a.StatusCodeAddress
                });
            }

            return addresses;
        }
    }
}