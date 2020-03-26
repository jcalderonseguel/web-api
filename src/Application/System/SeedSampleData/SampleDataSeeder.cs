using Application.Common.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly IClientDbContext _context;

        private readonly List<TimeZones> TimeZones = new List<TimeZones> {
            new TimeZones {
                TimeZoneId = 1,
                Description = "GMT",
                Number = "1",
            },

            new TimeZones {
                TimeZoneId = 2,
                Description = "UTC",
                Number = "1",
            },
        };

        private readonly List<StatusCodesAddresses> StatusCodesAddress = new List<StatusCodesAddresses> {
            new StatusCodesAddresses{
                StatusCodeAddressId = 1,
                Description = "Active"
            },

            new StatusCodesAddresses{
                StatusCodeAddressId = 2,
                Description = "Inactive"
            },
        };

        private readonly List<RolesTypes> RolesTypes = new List<RolesTypes>
        {
            new RolesTypes{
                RoleTypeId = 1,
                Description = "Administrador"
            },
            new RolesTypes{
                RoleTypeId = 2,
                Description = "Recurso Humano"
            },
        };

        private readonly List<RegionsCodes> RegionsCodes = new List<RegionsCodes>
        {
            new RegionsCodes{
                RegionCodeId = 1,
                Description = "+56",
            },

            new RegionsCodes{
                RegionCodeId = 2,
                Description = "+58",
            }
        };

        private readonly List<PhonesTypes> PhonesTypes = new List<PhonesTypes>
        {
            new PhonesTypes {
                PhoneTypeId = 1,
                Description = "Fijo"
            },
            new PhonesTypes {
                PhoneTypeId = 2,
                Description = "Móvil"
            }
        };

        private readonly List<Periodicity> Periodicities = new List<Periodicity> {
            new Periodicity {
                PeriodicityId = 1,
                Description = "Day"
            },
            new Periodicity {
                PeriodicityId = 2,
                Description = "Week"
            },
            new Periodicity {
                PeriodicityId = 3,
                Description = "Month"
            },
            new Periodicity {
                PeriodicityId = 4,
                Description = "Year"
            },
        };

        private readonly List<MaritalStatus> MaritalStatus = new List<MaritalStatus>
        {
            new MaritalStatus {
                MaritalStatusId = 1,
                Description = "Soltero"
            },

            new MaritalStatus {
                MaritalStatusId = 2,
                Description = "Casado"
            },

            new MaritalStatus {
                MaritalStatusId = 3,
                Description = "viudo"
            },

            new MaritalStatus {
                MaritalStatusId = 4,
                Description = "Separado"
            },
        };

        private readonly List<Genders> Genders = new List<Genders> {
            new Genders{
                GenderId = 1,
                Description = "Femenino"
            },
            new Genders{
                GenderId = 2,
                Description = "Masculino"
            },
        };

        private readonly List<DocumentsTypes> DocumentsTypes = new List<DocumentsTypes>
        {
            new DocumentsTypes{
                DocumentTypeId = 1,
                Typecode = "RUN",
                Description = "Numero de identificacion Chilena",
            },
            new DocumentsTypes{
                DocumentTypeId = 2,
                Typecode = "DNI",
                Description = "Documento Nacional de Identificacion",
            },
            new DocumentsTypes{
                DocumentTypeId = 3,
                Typecode = "Pasaporte",
                Description = "Documento de Indentificacion Internacional",
            },
             new DocumentsTypes{
                DocumentTypeId = 4,
                Typecode = "CPF",
                Description = "Cadastro de Pessoas Físicas",
             },
              new DocumentsTypes{
                DocumentTypeId = 5,
                Typecode = "CC",
                Description = "Cédula de Ciudadania",
              },
               new DocumentsTypes{
                DocumentTypeId = 6,
                Typecode = "CE",
                Description = "Cédula de Extranjería",
               },
               new DocumentsTypes{
                DocumentTypeId = 7,
                Typecode = "INE",
                Description = "Instituto Nacional Electoral",
               },
               new DocumentsTypes{
                DocumentTypeId = 8,
                Typecode = "IFE",
                Description = "Instituto Federal Electoral",
               },
        };

        private readonly List<ClientsStatus> ClientsStatus = new List<ClientsStatus> {
            new ClientsStatus {
                ClientStatusId = 1,
                Description = "Active"
            },

            new ClientsStatus {
                ClientStatusId = 2,
                Description = "Inactive"
            },
        };

        private readonly List<Categories> Categories = new List<Categories>
        {
            new Categories {
                CategoryId = 1,
                Description = "Natural"
            },

            new Categories {
                CategoryId = 2,
                Description = "Legal"
            },
        };

        private readonly List<AttachmentsTypes> AttachmentsTypes = new List<AttachmentsTypes> {
            new AttachmentsTypes {
                AttachmentTypeId = 1,
                Description = "Documentos"
            },

             new AttachmentsTypes {
                AttachmentTypeId = 2,
                Description = "Imagenes"
            },
        };

        private readonly List<AddressesTypes> AddressesTypes = new List<AddressesTypes> {
            new AddressesTypes{
                AddressTypeId = 1,
                Description = "Particular"
            },

            new AddressesTypes{
                AddressTypeId = 2,
                Description = "Comercial"
            },
        };

        private readonly List<Currencies> Currencies = new List<Currencies>
        {
            new Currencies {
                IsoCode = "CLP",
                IsoNumber = 1,
                IsoDecimal = 1,
                Description = "Peso Chileno"
            },

            new Currencies {
                IsoCode = "ARS",
                IsoNumber = 1,
                IsoDecimal = 1,
                Description = "Peso Argentino"
            },

            new Currencies {
                IsoCode = "BRL",
                IsoNumber = 1,
                IsoDecimal = 1,
                Description = "Brasil Real"
            },

            new Currencies {
                IsoCode = "USD",
                IsoNumber = 1,
                IsoDecimal = 1,
                Description = "Dólar Estaudinense"
            },

            new Currencies {
                IsoCode = "AUD",
                IsoNumber = 1,
                IsoDecimal = 1,
                Description = "Dólar de Australia"
            },

            new Currencies {
                IsoCode = "EUR",
                IsoNumber = 1,
                IsoDecimal = 1,
                Description = "Países miembro de la zona del euro"
            },
        };

        private readonly List<RuleForPostalsCodes> RuleForPostalsCodes = new List<RuleForPostalsCodes>
        {
            new RuleForPostalsCodes {
                RuleForPostalCodeId = 1,
                Description = "Postal Code Chile"
            },
            new RuleForPostalsCodes {
                RuleForPostalCodeId = 2,
                Description = "Postal Code Argentina"
            },
            new RuleForPostalsCodes {
                RuleForPostalCodeId = 3,
                Description = "Postal Code Brasil"
            }
        };

        private readonly List<FormattingRoutinesKeysForPrintingAddresses> FormattingRoutinesKeysForPrintingAddresses = new List<FormattingRoutinesKeysForPrintingAddresses> {
            new FormattingRoutinesKeysForPrintingAddresses{
                FormattingRoutineKeyForPrintingAddressesId = 1,
                Description = "FormattingAddress1"
            },

            new FormattingRoutinesKeysForPrintingAddresses{
                FormattingRoutineKeyForPrintingAddressesId = 2,
                Description = "FormattingAddress2"
            },

            new FormattingRoutinesKeysForPrintingAddresses{
                FormattingRoutineKeyForPrintingAddressesId = 3,
                Description = "FormattingAddress3"
            },
        };

        private readonly List<LanguagesKeys> LanguagesKeys = new List<LanguagesKeys>
        {
            new LanguagesKeys {
                LanguageKeyId = 1,
                Description = "Spanish"
            },
             new LanguagesKeys {
                LanguageKeyId = 2,
                Description = "English"
            },
              new LanguagesKeys {
                LanguageKeyId = 3,
                Description = "Portugues"
            },
        };

        private readonly List<Countries> Countries = new List<Countries>{
                new Countries {
                    CountryIsoCode = "CHL",
                    Description = "Chile",
                    CountryIsoNumb = 1,
                    PrincipalCurrency = "CLP",
                    RuleForPostalCode = 1,
                    FormattingRoutineKeyForPrintingAddresses = 1,
                    LanguageKey = 1,
                    Nationality = "Chileno(a)",
                    IsoCountryName = "Chile",
                    OfficialStateName = "Santiago"
                },

                new Countries {
                    CountryIsoCode = "ARG",
                    Description = "Argentina",
                    CountryIsoNumb = 1,
                    PrincipalCurrency = "ARS",
                    RuleForPostalCode = 1,
                    FormattingRoutineKeyForPrintingAddresses = 1,
                    LanguageKey = 1,
                    Nationality = "Argentino(a)",
                    IsoCountryName = "Argentina",
                    OfficialStateName = "Buenos Aires"
                },

                new Countries {
                    CountryIsoCode = "BRA",
                    Description = "Brasil",
                    CountryIsoNumb = 1,
                    PrincipalCurrency = "BRL",
                    RuleForPostalCode = 1,
                    FormattingRoutineKeyForPrintingAddresses = 1,
                    LanguageKey = 1,
                    Nationality = "Brasileño(a)",
                    IsoCountryName = "Brasil",
                    OfficialStateName = "Rio De Janeiro"
                },
            };

        private readonly List<Regions> Regions = new List<Regions> {
            new Regions {
                RegionCode = 1,
                Country = "CHL",
                Description = "Región Metropolitana, Chile",
                TimeZone = 1
            },

            new Regions {
                RegionCode = 2,
                Country = "ARG",
                Description = "Buenos Aires, Argentina",
                TimeZone = 1
            },
        };

        private readonly List<States> States = new List<States> {
            new States {
                Region = 1,
                StateCode = 837,
                Description = "Zona Central"
            }
        };

        private readonly List<Cities> Cities = new List<Cities> {
            new Cities {
              State =  1,
              CityCode = 562,
              Description = "+56-2 Santiago, Chile",
              PostalCode = "8320000",
            },

            new Cities {
              State =  1,
              CityCode = 5411,
              Description = "+54-11 Buenos Aires, Argentina",
              PostalCode = "1000-1499",
            },
        };

        public SampleDataSeeder(IClientDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (_context.TimeZones.Count() != TimeZones.Count)
            {
                await SeedTimeZoneAsync(cancellationToken);
            }

            if (_context.StatusCodesAddresses.Count() != StatusCodesAddress.Count)
            {
                await SeedStatusCodesAddressAsync(cancellationToken);
            }

            if (_context.RolesTypes.Count() != RolesTypes.Count)
            {
                await SeedRoleTypesAsync(cancellationToken);
            }

            if (_context.RegionsCodes.Count() != RegionsCodes.Count)
            {
                await SeedRegionCodeAsync(cancellationToken);
            }

            if (_context.PhonesTypes.Count() != PhonesTypes.Count)
            {
                await SeedPhoneTypeAsync(cancellationToken);
            }

            if (_context.Periodicity.Count() != Periodicities.Count)
            {
                await SeedPeriodicityAsync(cancellationToken);
            }

            if (_context.MaritalStatus.Count() != MaritalStatus.Count)
            {
                await SeedMaritalStatusAsync(cancellationToken);
            }

            if (_context.Genders.Count() != Genders.Count)
            {
                await SeedGenderAsync(cancellationToken);
            }

            if (_context.DocumentsTypes.Count() != DocumentsTypes.Count)
            {
                await SeedDocumentsTypesAsync(cancellationToken);
            }

            if (_context.ClientsStatus.Count() != ClientsStatus.Count)
            {
                await SeedClientsStatusAsync(cancellationToken);
            }

            if (_context.Categories.Count() != Categories.Count)
            {
                await SeedCategoriesAsync(cancellationToken);
            }

            if (_context.AttachmentsTypes.Count() != AttachmentsTypes.Count)
            {
                await SeedAttachmentsTypesAsync(cancellationToken);
            }

            if (_context.AddressesTypes.Count() != AddressesTypes.Count)
            {
                await SeedAddressTypesAsync(cancellationToken);
            }

            if (_context.Currencies.Count() != Currencies.Count)
            {
                await SeedCurrenciesAsync(cancellationToken);
            }

            if (_context.RuleForPostalsCodes.Count() != RuleForPostalsCodes.Count)
            {
                await SeedRuleForPostalCodeAsync(cancellationToken);
            }

            if (_context.FormattingRoutinesKeysForPrintingAddresses.Count() != FormattingRoutinesKeysForPrintingAddresses.Count)
            {
                await SeedFormattingRoutinesKeysForPrintingAddressesAsync(cancellationToken);
            }

            if (_context.LanguagesKeys.Count() != LanguagesKeys.Count)
            {
                await SeedLanguageKeyAsync(cancellationToken);
            }

            if (_context.Countries.Count() != Countries.Count)
            {
                await SeedCountriesAsync(cancellationToken);
            }

            if (_context.Regions.Count() != Regions.Count)
            {
                await SeedRegionsAsync(cancellationToken);
            }

            if (_context.States.Count() != States.Count)
            {
                await SeedStatesAsync(cancellationToken);
            }

            if (_context.Cities.Count() != Cities.Count)
            {
                await SeedCitiesAsync(cancellationToken);
            }
        }

        private async Task SeedTimeZoneAsync(CancellationToken cancellationToken)
        {
            foreach (var item in TimeZones)
            {
                if (!_context.TimeZones.Any(x => x.Description == item.Description)) _context.TimeZones.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedStatusCodesAddressAsync(CancellationToken cancellationToken)
        {
            foreach (var item in StatusCodesAddress)
            {
                if (!_context.StatusCodesAddresses.Any(x => x.Description == item.Description)) _context.StatusCodesAddresses.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRoleTypesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in RolesTypes)
            {
                if (!_context.RolesTypes.Any(x => x.Description == item.Description)) _context.RolesTypes.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRegionCodeAsync(CancellationToken cancellationToken)
        {
            foreach (var item in RegionsCodes)
            {
                if (!_context.RegionsCodes.Any(x => x.Description == item.Description)) _context.RegionsCodes.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedPhoneTypeAsync(CancellationToken cancellationToken)
        {
            foreach (var item in PhonesTypes)
            {
                if (!_context.PhonesTypes.Any(x => x.Description == item.Description)) _context.PhonesTypes.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedPeriodicityAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Periodicities)
            {
                if (!_context.Periodicity.Any(x => x.Description == item.Description)) _context.Periodicity.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMaritalStatusAsync(CancellationToken cancellationToken)
        {
            foreach (var item in MaritalStatus)
            {
                if (!_context.MaritalStatus.Any(x => x.Description == item.Description)) _context.MaritalStatus.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedGenderAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Genders)
            {
                if (!_context.Genders.Any(x => x.Description == item.Description)) _context.Genders.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedDocumentsTypesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in DocumentsTypes)
            {
                if (!_context.DocumentsTypes.Any(x => x.Description == item.Description)) _context.DocumentsTypes.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedClientsStatusAsync(CancellationToken cancellationToken)
        {
            foreach (var item in ClientsStatus)
            {
                if (!_context.ClientsStatus.Any(x => x.Description == item.Description)) _context.ClientsStatus.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedCategoriesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Categories)
            {
                if (!_context.Categories.Any(x => x.Description == item.Description)) _context.Categories.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedAttachmentsTypesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in AttachmentsTypes)
            {
                if (!_context.AttachmentsTypes.Any(x => x.Description == item.Description)) _context.AttachmentsTypes.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedAddressTypesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in AddressesTypes)
            {
                if (!_context.AddressesTypes.Any(x => x.Description == item.Description)) _context.AddressesTypes.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedCurrenciesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Currencies)
            {
                if (!_context.Currencies.Any(x => x.Description == item.Description)) _context.Currencies.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRuleForPostalCodeAsync(CancellationToken cancellationToken)
        {
            foreach (var item in RuleForPostalsCodes)
            {
                if (!_context.RuleForPostalsCodes.Any(x => x.Description == item.Description)) _context.RuleForPostalsCodes.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedFormattingRoutinesKeysForPrintingAddressesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in FormattingRoutinesKeysForPrintingAddresses)
            {
                if (!_context.FormattingRoutinesKeysForPrintingAddresses.Any(x => x.Description == item.Description)) _context.FormattingRoutinesKeysForPrintingAddresses.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedLanguageKeyAsync(CancellationToken cancellationToken)
        {
            foreach (var item in LanguagesKeys)
            {
                if (!_context.LanguagesKeys.Any(x => x.Description == item.Description)) _context.LanguagesKeys.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedCountriesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Countries)
            {
                if (!_context.Countries.Any(x => x.Description == item.Description)) _context.Countries.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRegionsAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Regions)
            {
                if (!_context.Regions.Any(x => x.Description == item.Description)) _context.Regions.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedStatesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in States)
            {
                if (!_context.States.Any(x => x.Description == item.Description)) _context.States.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedCitiesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Cities)
            {
                if (!_context.Cities.Any(x => x.Description == item.Description)) _context.Cities.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}