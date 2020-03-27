using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance
{
    public class ClientDbContext : DbContext, IClientDbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => new { e.Person, e.AddressType, e.ValidFrom })
                    .IsClustered(false);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.AddressLine)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Coname)
                    .HasColumnName("COName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("numeric(11, 8)");

                entity.Property(e => e.Longitude).HasColumnType("numeric(11, 8)");

                entity.Property(e => e.PoboxPostalCode)
                    .HasColumnName("POBoxPostalCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostOfficeBoxCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Neighborhood)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.AddressTypeNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.AddressType)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.City);

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StatusCodeAddressNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StatusCodeAddress);
            });

            modelBuilder.Entity<AddressesTypes>(entity =>
            {
                entity.HasKey(e => e.AddressTypeId);

                entity.Property(e => e.AddressTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.HasKey(e => new { e.Person, e.AttachmentType })
                    .IsClustered(false);

                entity.Property(e => e.EncodedKey)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileSize).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerKey)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AttachmentTypeNavigation)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.AttachmentType)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AttachmentsTypes>(entity =>
            {
                entity.HasKey(e => e.AttachmentTypeId);

                entity.Property(e => e.AttachmentTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ClientsStatus>(entity =>
            {
                entity.HasKey(e => e.ClientStatusId);

                entity.Property(e => e.ClientStatusId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryIsoCode);

                entity.Property(e => e.CountryIsoCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsoCountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfficialStateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrincipalCurrency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.FormattingRoutineKeyForPrintingAddressesNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.FormattingRoutineKeyForPrintingAddresses)
                    .HasConstraintName("FK_Countries_FormattingRoutinesKeysForPrintingAddresses_FormattinRoutineKeyForPrintingAddresses");

                entity.HasOne(d => d.LanguageKeyNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.LanguageKey)
                    .HasConstraintName("FK_Countries_LanguagesKeys_LanguajeKey");

                entity.HasOne(d => d.PrincipalCurrencyNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.PrincipalCurrency)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.RuleForPostalCodeNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RuleForPostalCode);
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.IsoCode);

                entity.Property(e => e.IsoCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DocumentsTypes>(entity =>
            {
                entity.HasKey(e => e.DocumentTypeId);

                entity.Property(e => e.DocumentTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Typecode)
                  .HasMaxLength(20)
                  .IsUnicode(false);
            });

            modelBuilder.Entity<Emails>(entity =>
            {
                entity.HasKey(e => new { e.Person, e.EmailAddress })
                    .IsClustered(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FormattingRoutinesKeysForPrintingAddresses>(entity =>
            {
                entity.HasKey(e => e.FormattingRoutineKeyForPrintingAddressesId);

                entity.Property(e => e.FormattingRoutineKeyForPrintingAddressesId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IdentificationsDocuments>(entity =>
            {
                entity.HasKey(e => new { e.IdentificationDocumentType, e.DocumentNumber })
                    .IsClustered(false);

                entity.HasIndex(e => e.Person);

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IssuingAuthority)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IssuingDate).HasColumnType("datetime");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.IdentificationDocumentTypeNavigation)
                    .WithMany(p => p.IdentificationsDocuments)
                    .HasForeignKey(d => d.IdentificationDocumentType)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.IdentificationsDocuments)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Incomes>(entity =>
            {
                entity.HasKey(e => new { e.Person, e.Company, e.Currency, e.Value })
                    .IsClustered(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PeriodicityNavigation)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.Periodicity)
                    .HasConstraintName("FK_Incomes_Periodicities_Periodicity");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LanguagesKeys>(entity =>
            {
                entity.HasKey(e => e.LanguageKeyId);

                entity.Property(e => e.LanguageKeyId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.Property(e => e.MaritalStatusId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NaturalPersons>(entity =>
            {
                entity.HasKey(e => e.Person)
                    .IsClustered(false);

                entity.Property(e => e.Person).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfDeath).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastNamePrefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Alias)
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.NaturalPersons)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.MaritalStatusNavigation)
                    .WithMany(p => p.NaturalPersons)
                    .HasForeignKey(d => d.MaritalStatus);

                entity.HasOne(d => d.NationalityNavigation)
                    .WithMany(p => p.NaturalPersons)
                    .HasForeignKey(d => d.Nationality)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PersonNavigation)
                    .WithOne(p => p.NaturalPersons)
                    .HasForeignKey<NaturalPersons>(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Periodicity>(entity =>
            {
                entity.Property(e => e.PeriodicityId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .IsClustered(false);

                entity.HasIndex(e => e.Category);

                entity.HasIndex(e => e.Status);

                entity.HasIndex(e => e.TransactionId)
                    .HasName("CIX_Persons_TransactionId")
                    .IsClustered();

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.Property(e => e.TransactionId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Phones>(entity =>
            {
                entity.HasKey(e => new { e.Person, e.PhoneType })
                    .IsClustered(false);

                entity.HasIndex(e => e.CountryIsoCode);

                entity.Property(e => e.AreaCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryIsoCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.CountryIsoCodeNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.CountryIsoCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PhoneTypeNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.PhoneType)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PhonesTypes>(entity =>
            {
                entity.HasKey(e => e.PhoneTypeId);

                entity.Property(e => e.PhoneTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.RegionCodeNavigation)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.RegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TimeZoneNavigation)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.TimeZone)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<RegionsCodes>(entity =>
            {
                entity.HasKey(e => e.RegionCodeId);

                entity.Property(e => e.RegionCodeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => new { e.Person, e.RoleType })
                    .IsClustered(false);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.RoleTypeNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.RoleType)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<RolesTypes>(entity =>
            {
                entity.HasKey(e => e.RoleTypeId);

                entity.Property(e => e.RoleTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RuleForPostalsCodes>(entity =>
            {
                entity.HasKey(e => e.RuleForPostalCodeId);

                entity.Property(e => e.RuleForPostalCodeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StatusCodesAddresses>(entity =>
            {
                entity.HasKey(e => e.StatusCodeAddressId);

                entity.Property(e => e.StatusCodeAddressId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TimeZones>(entity =>
            {
                entity.HasKey(e => e.TimeZoneId);

                entity.Property(e => e.TimeZoneId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .IsClustered(false);
             
                entity.Property(e => e.Password)
                  .IsRequired()
                  .HasMaxLength(125)
                  .IsUnicode(false);

                entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.Property(e => e.Token)
               .IsRequired()
               .HasMaxLength(125)
               .IsUnicode(false);

                entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.Property(e => e.UserName)
               .IsRequired()
               .HasMaxLength(250)
               .IsUnicode(false);

                entity.Property(e => e.Email)
              .IsRequired()
              .HasMaxLength(250)
              .IsUnicode(false);

               entity.Property(e => e.Created).HasColumnType("datetime");




            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientDbContext).Assembly);
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressesTypes> AddressesTypes { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<AttachmentsTypes> AttachmentsTypes { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<ClientsStatus> ClientsStatus { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<DocumentsTypes> DocumentsTypes { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<FormattingRoutinesKeysForPrintingAddresses> FormattingRoutinesKeysForPrintingAddresses { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<IdentificationsDocuments> IdentificationsDocuments { get; set; }
        public virtual DbSet<Incomes> Incomes { get; set; }
        public virtual DbSet<LanguagesKeys> LanguagesKeys { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<NaturalPersons> NaturalPersons { get; set; }
        public virtual DbSet<Periodicity> Periodicity { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<PhonesTypes> PhonesTypes { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<RegionsCodes> RegionsCodes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesTypes> RolesTypes { get; set; }
        public virtual DbSet<RuleForPostalsCodes> RuleForPostalsCodes { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<StatusCodesAddresses> StatusCodesAddresses { get; set; }
        public virtual DbSet<TimeZones> TimeZones { get; set; }

        public virtual DbSet<Users> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}