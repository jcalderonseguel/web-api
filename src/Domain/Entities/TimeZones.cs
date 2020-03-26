using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TimeZones
    {
        public TimeZones()
        {
            Regions = new HashSet<Regions>();
        }

        public int TimeZoneId { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }

        public virtual ICollection<Regions> Regions { get; set; }
    }
}