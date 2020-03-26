using System;
using System.Collections.Generic;

namespace Application.Queries
{
    public class ShortPersonDto
    {
        public Guid PersonId { get; set; }
        public int PersonCategory { get; set; }
        public NaturalPersonsDto Person { get; set; }
    }
}