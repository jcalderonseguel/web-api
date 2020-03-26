using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class RegionsCodes
    {
        public RegionsCodes()
        {
            Regions = new HashSet<Regions>();
        }

        public int RegionCodeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Regions> Regions { get; set; }
    }
}