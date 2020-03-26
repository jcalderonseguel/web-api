using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Commands
{
    public class PersonDataRepository : IPersonDataRepository
    {
        private readonly ClientDbContext context;

        public PersonDataRepository(ClientDbContext context)
        {
            this.context = context;
        }

        public async Task InsertAsync(Persons personData)
        {
            await context.Persons.AddAsync(personData);
        }

        public async Task<Persons> GetPersonByDocumentNumber(int genderId
           , string countryId, int identificationDocumentTypeId, string documentNumber)
        {
            //var req = request;
            return await context.Persons.Include(x => x.NaturalPersons).Where(i => i.NaturalPersons.Gender == genderId && i.IdentificationsDocuments.Any(d => d.PersonNavigation.NaturalPersons.Nationality == countryId && d.IdentificationDocumentType == identificationDocumentTypeId && d.DocumentNumber == documentNumber)).FirstOrDefaultAsync();
        }

        public DocumentsTypes GetIdentificationDocumentTypeById(long id)
        {
            var typeDoc = context.DocumentsTypes
                                      .Where(s => s.DocumentTypeId == id)
                                      .FirstOrDefault();

            return typeDoc;
        }

        public IdentificationsDocuments GetDocumentNumber(Guid personId)
        {
            var doc = context.IdentificationsDocuments
                                      .Where(s => s.Person == personId)
                                      .FirstOrDefault();

            return doc;
        }

        public Roles GetRoleById(Guid personId, int roleType)
        {
            var role = context.Roles.Where(s => s.RoleType == roleType && s.Person == personId).FirstOrDefault();

            return role;
        }

        public Genders GetGenderById(int id)
        {
            var gender = context.Genders.Where(s => s.GenderId == id).FirstOrDefault();

            return gender;
        }

        public async ValueTask<Persons> GetByIdAsync(Guid personId)
        {
            return await context.Persons
                .Include(np => np.NaturalPersons)
                .Include(g => g.NaturalPersons.GenderNavigation)
                .Include(ms => ms.NaturalPersons.MaritalStatusNavigation)
                .Include(nn => nn.NaturalPersons.NationalityNavigation)
                .Include(f => f.Phones)
                .Include(e => e.Emails)
                .Include(c => c.CategoryNavigation)
                .Include(i => i.IdentificationsDocuments).ThenInclude(d => d.IdentificationDocumentTypeNavigation)
                .Where(p => p.PersonId == personId).FirstOrDefaultAsync();
        }
    }
}