using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressesTypes",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressesTypes", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsTypes",
                columns: table => new
                {
                    AttachmentTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsTypes", x => x.AttachmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ClientsStatus",
                columns: table => new
                {
                    ClientStatusId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsStatus", x => x.ClientStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    IsoCode = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    IsoNumber = table.Column<int>(nullable: false),
                    IsoDecimal = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.IsoCode);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsTypes",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Typecode = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsTypes", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FormattingRoutinesKeysForPrintingAddresses",
                columns: table => new
                {
                    FormattingRoutineKeyForPrintingAddressesId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormattingRoutinesKeysForPrintingAddresses", x => x.FormattingRoutineKeyForPrintingAddressesId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "LanguagesKeys",
                columns: table => new
                {
                    LanguageKeyId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagesKeys", x => x.LanguageKeyId);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    MaritalStatusId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.MaritalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Periodicity",
                columns: table => new
                {
                    PeriodicityId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodicity", x => x.PeriodicityId);
                });

            migrationBuilder.CreateTable(
                name: "PhonesTypes",
                columns: table => new
                {
                    PhoneTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhonesTypes", x => x.PhoneTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RegionsCodes",
                columns: table => new
                {
                    RegionCodeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionsCodes", x => x.RegionCodeId);
                });

            migrationBuilder.CreateTable(
                name: "RolesTypes",
                columns: table => new
                {
                    RoleTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesTypes", x => x.RoleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RuleForPostalsCodes",
                columns: table => new
                {
                    RuleForPostalCodeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleForPostalsCodes", x => x.RuleForPostalCodeId);
                });

            migrationBuilder.CreateTable(
                name: "StatusCodesAddresses",
                columns: table => new
                {
                    StatusCodeAddressId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCodesAddresses", x => x.StatusCodeAddressId);
                });

            migrationBuilder.CreateTable(
                name: "TimeZones",
                columns: table => new
                {
                    TimeZoneId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Number = table.Column<string>(unicode: false, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.TimeZoneId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 125, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Token = table.Column<string>(unicode: false, maxLength: 125, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    TransactionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonNumber = table.Column<long>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Persons_Categories_Category",
                        column: x => x.Category,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_ClientsStatus_Status",
                        column: x => x.Status,
                        principalTable: "ClientsStatus",
                        principalColumn: "ClientStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryIsoCode = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CountryIsoNumb = table.Column<int>(nullable: false),
                    PrincipalCurrency = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    PostalCodeLength = table.Column<int>(nullable: true),
                    RuleForPostalCode = table.Column<int>(nullable: true),
                    FormattingRoutineKeyForPrintingAddresses = table.Column<int>(nullable: true),
                    LanguageKey = table.Column<int>(nullable: true),
                    Nationality = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsoCountryName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    OfficialStateName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryIsoCode);
                    table.ForeignKey(
                        name: "FK_Countries_FormattingRoutinesKeysForPrintingAddresses_FormattinRoutineKeyForPrintingAddresses",
                        column: x => x.FormattingRoutineKeyForPrintingAddresses,
                        principalTable: "FormattingRoutinesKeysForPrintingAddresses",
                        principalColumn: "FormattingRoutineKeyForPrintingAddressesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_LanguagesKeys_LanguajeKey",
                        column: x => x.LanguageKey,
                        principalTable: "LanguagesKeys",
                        principalColumn: "LanguageKeyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_PrincipalCurrency",
                        column: x => x.PrincipalCurrency,
                        principalTable: "Currencies",
                        principalColumn: "IsoCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_RuleForPostalsCodes_RuleForPostalCode",
                        column: x => x.RuleForPostalCode,
                        principalTable: "RuleForPostalsCodes",
                        principalColumn: "RuleForPostalCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Person = table.Column<Guid>(nullable: false),
                    AttachmentType = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Notes = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    OwnerKey = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EncodedKey = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FileSize = table.Column<decimal>(type: "numeric(18, 5)", nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Location = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => new { x.Person, x.AttachmentType })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Attachments_AttachmentsTypes_AttachmentType",
                        column: x => x.AttachmentType,
                        principalTable: "AttachmentsTypes",
                        principalColumn: "AttachmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Persons_Person",
                        column: x => x.Person,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Person = table.Column<Guid>(nullable: false),
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 320, nullable: false),
                    Validated = table.Column<bool>(nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => new { x.Person, x.EmailAddress })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Emails_Persons_Person",
                        column: x => x.Person,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationsDocuments",
                columns: table => new
                {
                    IdentificationDocumentType = table.Column<int>(nullable: false),
                    DocumentNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Person = table.Column<Guid>(nullable: false),
                    IssuingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IssuingAuthority = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationsDocuments", x => new { x.IdentificationDocumentType, x.DocumentNumber })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_IdentificationsDocuments_DocumentsTypes_IdentificationDocumentType",
                        column: x => x.IdentificationDocumentType,
                        principalTable: "DocumentsTypes",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentificationsDocuments_Persons_Person",
                        column: x => x.Person,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Person = table.Column<Guid>(nullable: false),
                    Company = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Currency = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    Value = table.Column<decimal>(type: "numeric(18, 5)", nullable: false),
                    Periodicity = table.Column<int>(nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => new { x.Person, x.Company, x.Currency, x.Value })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Incomes_Currencies_Currency",
                        column: x => x.Currency,
                        principalTable: "Currencies",
                        principalColumn: "IsoCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_Periodicities_Periodicity",
                        column: x => x.Periodicity,
                        principalTable: "Periodicity",
                        principalColumn: "PeriodicityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_Persons_Person",
                        column: x => x.Person,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Person = table.Column<Guid>(nullable: false),
                    RoleType = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => new { x.Person, x.RoleType })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Roles_Persons_Person",
                        column: x => x.Person,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_RolesTypes_RoleType",
                        column: x => x.RoleType,
                        principalTable: "RolesTypes",
                        principalColumn: "RoleTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersons",
                columns: table => new
                {
                    Person = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    LastNamePrefix = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    FullName = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: true),
                    Nationality = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    Alias = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersons", x => x.Person)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_NaturalPersons_Genders_Gender",
                        column: x => x.Gender,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NaturalPersons_MaritalStatus_MaritalStatus",
                        column: x => x.MaritalStatus,
                        principalTable: "MaritalStatus",
                        principalColumn: "MaritalStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NaturalPersons_Countries_Nationality",
                        column: x => x.Nationality,
                        principalTable: "Countries",
                        principalColumn: "CountryIsoCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NaturalPersons_Persons_Person",
                        column: x => x.Person,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Person = table.Column<Guid>(nullable: false),
                    PhoneType = table.Column<int>(nullable: false),
                    CountryIsoCode = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    AreaCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Extension = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => new { x.Person, x.PhoneType })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Phones_Countries_CountryIsoCode",
                        column: x => x.CountryIsoCode,
                        principalTable: "Countries",
                        principalColumn: "CountryIsoCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phones_Persons_Person",
                        column: x => x.Person,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phones_PhonesTypes_PhoneType",
                        column: x => x.PhoneType,
                        principalTable: "PhonesTypes",
                        principalColumn: "PhoneTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionCode = table.Column<int>(nullable: false),
                    Country = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TimeZone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_Country",
                        column: x => x.Country,
                        principalTable: "Countries",
                        principalColumn: "CountryIsoCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regions_RegionsCodes_RegionCode",
                        column: x => x.RegionCode,
                        principalTable: "RegionsCodes",
                        principalColumn: "RegionCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regions_TimeZones_TimeZone",
                        column: x => x.TimeZone,
                        principalTable: "TimeZones",
                        principalColumn: "TimeZoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StatesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<int>(nullable: false),
                    StateCode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StatesId);
                    table.ForeignKey(
                        name: "FK_States_Regions_Region",
                        column: x => x.Region,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(nullable: false),
                    CityCode = table.Column<int>(nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_States_State",
                        column: x => x.State,
                        principalTable: "States",
                        principalColumn: "StatesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Person = table.Column<Guid>(nullable: false),
                    AddressType = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    City = table.Column<int>(nullable: true),
                    StatusCodeAddress = table.Column<int>(nullable: true),
                    PostCode = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    StreetName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    BuildingNumber = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    AddressLine = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(11, 8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "numeric(11, 8)", nullable: true),
                    PostOfficeBoxCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    POBoxPostalCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    COName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    Neighborhood = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => new { x.Person, x.AddressType, x.ValidFrom })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Address_AddressesTypes_AddressType",
                        column: x => x.AddressType,
                        principalTable: "AddressesTypes",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Cities_City",
                        column: x => x.City,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Persons_Person",
                        column: x => x.Person,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_StatusCodesAddresses_StatusCodeAddress",
                        column: x => x.StatusCodeAddress,
                        principalTable: "StatusCodesAddresses",
                        principalColumn: "StatusCodeAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressType",
                table: "Address",
                column: "AddressType");

            migrationBuilder.CreateIndex(
                name: "IX_Address_City",
                table: "Address",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StatusCodeAddress",
                table: "Address",
                column: "StatusCodeAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AttachmentType",
                table: "Attachments",
                column: "AttachmentType");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_State",
                table: "Cities",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_FormattingRoutineKeyForPrintingAddresses",
                table: "Countries",
                column: "FormattingRoutineKeyForPrintingAddresses");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageKey",
                table: "Countries",
                column: "LanguageKey");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_PrincipalCurrency",
                table: "Countries",
                column: "PrincipalCurrency");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RuleForPostalCode",
                table: "Countries",
                column: "RuleForPostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_IdentificationsDocuments_Person",
                table: "IdentificationsDocuments",
                column: "Person");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_Currency",
                table: "Incomes",
                column: "Currency");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_Periodicity",
                table: "Incomes",
                column: "Periodicity");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersons_Gender",
                table: "NaturalPersons",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersons_MaritalStatus",
                table: "NaturalPersons",
                column: "MaritalStatus");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersons_Nationality",
                table: "NaturalPersons",
                column: "Nationality");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Category",
                table: "Persons",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Status",
                table: "Persons",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "CIX_Persons_TransactionId",
                table: "Persons",
                column: "TransactionId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CountryIsoCode",
                table: "Phones",
                column: "CountryIsoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneType",
                table: "Phones",
                column: "PhoneType");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Country",
                table: "Regions",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RegionCode",
                table: "Regions",
                column: "RegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_TimeZone",
                table: "Regions",
                column: "TimeZone");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleType",
                table: "Roles",
                column: "RoleType");

            migrationBuilder.CreateIndex(
                name: "IX_States_Region",
                table: "States",
                column: "Region");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "IdentificationsDocuments");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "NaturalPersons");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AddressesTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "StatusCodesAddresses");

            migrationBuilder.DropTable(
                name: "AttachmentsTypes");

            migrationBuilder.DropTable(
                name: "DocumentsTypes");

            migrationBuilder.DropTable(
                name: "Periodicity");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropTable(
                name: "PhonesTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RolesTypes");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ClientsStatus");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "RegionsCodes");

            migrationBuilder.DropTable(
                name: "TimeZones");

            migrationBuilder.DropTable(
                name: "FormattingRoutinesKeysForPrintingAddresses");

            migrationBuilder.DropTable(
                name: "LanguagesKeys");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "RuleForPostalsCodes");
        }
    }
}
