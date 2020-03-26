using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class AddressesTypes
    {
        public AddressesTypes()
        {
            Address = new HashSet<Address>();
        }

        public int AddressTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}