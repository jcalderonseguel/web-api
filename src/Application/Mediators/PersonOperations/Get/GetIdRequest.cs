using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Application.Notifications;
using System.Text.RegularExpressions;

namespace Application.Mediators.PersonOperations.Get
{
    public class GetIdRequest : Notifiable, IRequest<EntityResult<GetIdResult>>
    {
        public GetIdRequest( int? identificationDocumentTypeId, string documentNumber, int? genderId, string email, string phoneNumber, string alias)
        {
            IdentificationDocumentTypeId = identificationDocumentTypeId;
            DocumentNumber = documentNumber;
            GenderId = genderId;
            Email = email;
            PhoneNumber = phoneNumber;
            Alias = alias;

            Validate();
        }

        public int? IdentificationDocumentTypeId { get; set; }
        public string DocumentNumber { get; set; }
        public int? GenderId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Alias { get; set; }

        private void Validate()
        {
            if (!string.IsNullOrWhiteSpace(Email))
                AddNotifications(new Contract()
                    .IsEmail(Email, nameof(Email), "Email's format is invalid."));

            if (!string.IsNullOrWhiteSpace(PhoneNumber) && !Regex.Match(PhoneNumber, @"^\+?[0-9]+$", RegexOptions.IgnoreCase).Success)
                AddNotification(nameof(PhoneNumber), "PhoneNumber's format is invalid.");
        }        
    }
}