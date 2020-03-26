using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            NaturalPersons = new HashSet<NaturalPersons>();
        }

        public int MaritalStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<NaturalPersons> NaturalPersons { get; set; }
    }
}