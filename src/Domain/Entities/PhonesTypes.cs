using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class PhonesTypes
    {
        public PhonesTypes()
        {
            Phones = new HashSet<Phones>();
        }

        public int PhoneTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Phones> Phones { get; set; }
    }
}