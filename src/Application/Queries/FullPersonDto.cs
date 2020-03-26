using System;
using System.Collections.Generic;

namespace Application.Queries
{
    public class FullPersonDto
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastNamePrefix { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int GenderId { get; set; }
        public string Description { get; set; } // Gender.description
        public string PersonCategory { get; set; }
        public virtual IEnumerable<PhonesDto> Phones { get; set; }

        public virtual IEnumerable<EmailDto> Emails { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }     
        public virtual IEnumerable<DocumentTypesDto> Documents { get; set; }
    }
}
