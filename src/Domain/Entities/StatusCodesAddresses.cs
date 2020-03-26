using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class StatusCodesAddresses
    {
        public StatusCodesAddresses()
        {
            Address = new HashSet<Address>();
        }

        public int StatusCodeAddressId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}