using FluentValidation.Results;
using MediatR;
using Application.Common.Interfaces;
using Application.Notifications;
using Application.Validations;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.Insert
{
    public class InserPersontHandler : IRequestHandler<InsertPersonRequest, EntityResult<PersonCreatedDto>>
    {
        private readonly IClientDbContext _context;

        public InserPersontHandler(IClientDbContext context)
        {
            _context = context;
        }

        public async Task<EntityResult<PersonCreatedDto>> Handle(InsertPersonRequest request, CancellationToken cancellationToken)
        {
            PersonValidator validator = new PersonValidator(_context);
            ValidationResult result = await validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    request.AddNotification(item.PropertyName, item.ErrorMessage);
                }

                return new EntityResult<PersonCreatedDto>(request.Notifications, result.Errors.All(err => err.ErrorCode == ErrorCode.NotFound.ToString()) ? ErrorCode.NotFound : ErrorCode.BadRequest);
            }

            NaturalPersons naturalPerson = new NaturalPersons()
            {
                FirstName = request.NaturalPerson.FirstName,
                LastName = request.NaturalPerson.LastName,
                LastNamePrefix = request.NaturalPerson.LastNamePrefix,
                FullName = request.NaturalPerson.FullName,
                BirthDate = request.NaturalPerson.BirthDate,
                DateOfDeath = (request.NaturalPerson.DateOfDeath.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(request.NaturalPerson.DateOfDeath)),
                MaritalStatus = (request.NaturalPerson.MaritalStatus != 0) ? request.NaturalPerson.MaritalStatus : new int?(),
                Nationality = request.NaturalPerson.Nationality,
                Gender = request.NaturalPerson.Gender,
                Alias = request.NaturalPerson.Alias
            };

            List<Incomes> incomes = new List<Incomes>();
            foreach (var i in request.Income)
            {
                var income = new Incomes
                {
                    Value = i.Value,
                    Currency = i.Currency,
                    Company = i.Company,
                    Periodicity = (i.Periodicity != 0) ? i.Periodicity : new int?(),
                    ValidFrom = i.ValidFrom,
                    ValidTo = (i.ValidTo.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(i.ValidTo)),
                };
                incomes.Add(income);
            }

            List<Address> addresses = new List<Address>();
            if (!request.Address.Equals(null))
            {
                foreach (var a in request.Address)
                {
                    var address = new Address
                    {
                        City = (a.City != 0) ? a.City : new int?(),
                        PostCode = a.PostCode,
                        StreetName = a.StreetName,
                        BuildingNumber = a.BuildingNumber,
                        AddressLine = a.AddressLine,
                        Latitude = a.Latitude,
                        Longitude = a.Longitude,
                        AddressType = a.AddressType,
                        PostOfficeBoxCode = a.PostOfficeBoxCode,
                        PoboxPostalCode = a.PoboxPostalCode,
                        StatusCodeAddress = (a.StatusCodeAddress != 0) ? a.StatusCodeAddress : new int?(),
                        Coname = a.Coname,
                        ValidFrom = a.ValidFrom,
                        ValidTo = (a.ValidTo.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(a.ValidTo)),
                        Neighborhood = a.Neighborhood
                    };

                    addresses.Add(address);
                }
            }

            List<IdentificationsDocuments> identificationDocuments = new List<IdentificationsDocuments>();
            if (!request.IdentificationDocument.Equals(null))
            {
                foreach (var i in request.IdentificationDocument)
                {
                    var d = new IdentificationsDocuments
                    {
                        DocumentNumber = i.DocumentNumber,
                        IssuingDate = (i.IssuingDate.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(i.IssuingDate)),
                        IssuingAuthority = i.IssuingAuthority,
                        ExpiryDate = (i.ExpiryDate.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(i.ExpiryDate)),
                        ValidFrom = i.ValidFrom,
                        ValidTo = (i.ValidTo.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(i.ValidTo)),
                        IdentificationDocumentType = i.IdentificationDocumentType
                    };
                    identificationDocuments.Add(d);
                };
            }

            List<Attachments> attachments = new List<Attachments>();
            if (!request.Attachment.Equals(null))
            {
                foreach (var a in request.Attachment)
                {
                    var attachment = new Attachments
                    {
                        FileName = a.FileName,
                        Notes = a.Notes,
                        AttachmentType = a.AttachmentType,
                        OwnerKey = a.OwnerKey,
                        FileSize = a.FileSize,
                        Name = a.Name,
                        EncodedKey = a.EncodedKey,
                        Location = a.Location,
                    };
                    attachments.Add(attachment);
                }
            }
            List<Emails> emails = new List<Emails>();
            if (!request.Email.Equals(null))
            {
                foreach (var e in request.Email)
                {
                    var email = new Emails
                    {
                        EmailAddress = e.EmailAddress,
                        Validated = e.Validated,
                        ValidFrom = e.ValidFrom,
                        ValidTo = (e.ValidTo.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(e.ValidTo)),
                    };
                    emails.Add(email);
                };
            }

            List<Phones> phones = new List<Phones>();
            if (!request.Phone.Equals(null))
            {
                foreach (var f in request.Phone)
                {
                    var phone = new Phones
                    {
                        CountryIsoCode = f.CountryIsoCode,
                        AreaCode = f.AreaCode,
                        PhoneNumber = f.PhoneNumber,
                        Extension = f.Extension,
                        PhoneType = f.PhoneType,
                        ValidFrom = f.ValidFrom,
                        ValidTo = (f.ValidTo.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(f.ValidTo)),
                    };
                    phones.Add(phone);
                }
            }

            List<Roles> roles = new List<Roles>();
            foreach (var item in request.Rol)
            {
                var rol = new Roles
                {
                    RoleType = item.RoleType,
                    ValidFrom = item.ValidFrom,
                    ValidTo = (item.ValidTo.Equals(null)) ? null : new DateTime?(Convert.ToDateTime(item.ValidTo)),
                };
                roles.Add(rol);
            }

            Persons person = new Persons
            {
                PersonId = Guid.NewGuid(),
                TransactionId = (request.Transaction == 0) ? new long() : request.Transaction,
                PersonNumber = request.PersonNumber,
                Category = request.Category,
                Status = request.Status,
                NaturalPersons = naturalPerson,
                Address = addresses,
                IdentificationsDocuments = identificationDocuments,
                Emails = emails,
                Phones = phones,
                Roles = roles,
                Attachments = attachments,
                Incomes = incomes
            };

            _context.Persons.Add(person);
            await _context.SaveChangesAsync(cancellationToken);

            return new EntityResult<PersonCreatedDto>(request.Notifications, new PersonCreatedDto
            {
                PersonId = person.PersonId
            });
        }
    }
}
