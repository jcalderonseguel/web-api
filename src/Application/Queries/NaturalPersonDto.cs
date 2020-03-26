using System;
using System.Collections.Generic;

namespace Application.Queries
{
    public class NaturalPersonDto
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastNamePrefix { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public int GenderId { get; set; }

        public List<IdentificationDocumentsDto> IdentificationDocuments { get; set; }
        public string ProfilePictureURL { get; set; }

    }
}
