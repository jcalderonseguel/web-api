using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Regions
    {
        public Regions()
        {
            States = new HashSet<States>();
        }

        public int RegionId { get; set; }
        public int RegionCode { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int TimeZone { get; set; }

        public virtual Countries CountryNavigation { get; set; }
        public virtual RegionsCodes RegionCodeNavigation { get; set; }
        public virtual TimeZones TimeZoneNavigation { get; set; }
        public virtual ICollection<States> States { get; set; }
    }
}