using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Cities
    {
        public Cities()
        {
            Address = new HashSet<Address>();
        }

        public int CityId { get; set; }
        public int State { get; set; }
        public int? CityCode { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }

        public virtual States StateNavigation { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}