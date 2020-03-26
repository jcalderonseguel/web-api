using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class RuleForPostalsCodes
    {
        public RuleForPostalsCodes()
        {
            Countries = new HashSet<Countries>();
        }

        public int RuleForPostalCodeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
    }
}