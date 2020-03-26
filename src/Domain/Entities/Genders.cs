using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Genders
    {
        public Genders()
        {
            NaturalPersons = new HashSet<NaturalPersons>();
        }

        public int GenderId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<NaturalPersons> NaturalPersons { get; set; }
    }
}