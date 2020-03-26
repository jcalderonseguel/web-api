using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class States
    {
        public States()
        {
            Cities = new HashSet<Cities>();
        }

        public int StatesId { get; set; }
        public int Region { get; set; }
        public int StateCode { get; set; }
        public string Description { get; set; }

        public virtual Regions RegionNavigation { get; set; }
        public virtual ICollection<Cities> Cities { get; set; }
    }
}