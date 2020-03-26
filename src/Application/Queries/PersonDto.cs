using System;

namespace Application.Queries
{
    public class PersonDto
    {
        public long PersonNumber { get; set; }
        public string PersonName { get; set; }

        public int Category { get; set; }
        public int RoleId { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool IsAccountHolder { get; set; }
    }

}