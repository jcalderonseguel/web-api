using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IClientDbContext
    {
        DbSet<Address> Address { get; set; }
        DbSet<AddressesTypes> AddressesTypes { get; set; }
        DbSet<Attachments> Attachments { get; set; }
        DbSet<AttachmentsTypes> AttachmentsTypes { get; set; }
        DbSet<Categories> Categories { get; set; }
        DbSet<Cities> Cities { get; set; }
        DbSet<ClientsStatus> ClientsStatus { get; set; }
        DbSet<Countries> Countries { get; set; }
        DbSet<Currencies> Currencies { get; set; }
        DbSet<DocumentsTypes> DocumentsTypes { get; set; }
        DbSet<Emails> Emails { get; set; }
        DbSet<FormattingRoutinesKeysForPrintingAddresses> FormattingRoutinesKeysForPrintingAddresses { get; set; }
        DbSet<Genders> Genders { get; set; }
        DbSet<IdentificationsDocuments> IdentificationsDocuments { get; set; }
        DbSet<Incomes> Incomes { get; set; }
        DbSet<LanguagesKeys> LanguagesKeys { get; set; }
        DbSet<MaritalStatus> MaritalStatus { get; set; }
        DbSet<NaturalPersons> NaturalPersons { get; set; }
        DbSet<Periodicity> Periodicity { get; set; }
        DbSet<Persons> Persons { get; set; }
        DbSet<Phones> Phones { get; set; }
        DbSet<PhonesTypes> PhonesTypes { get; set; }
        DbSet<Regions> Regions { get; set; }
        DbSet<RegionsCodes> RegionsCodes { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<RolesTypes> RolesTypes { get; set; }
        DbSet<RuleForPostalsCodes> RuleForPostalsCodes { get; set; }
        DbSet<States> States { get; set; }
        DbSet<StatusCodesAddresses> StatusCodesAddresses { get; set; }
        DbSet<TimeZones> TimeZones { get; set; }

        DbSet<Users> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}