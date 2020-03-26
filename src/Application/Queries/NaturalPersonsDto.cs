using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class NaturalPersonsDto
    {
        public string FirstName { get; set; }
        public string LastNamePrefix { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public GenderDto Gender { get; set; }
    }
}
