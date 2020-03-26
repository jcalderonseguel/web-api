using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class FormattingRoutinesKeysForPrintingAddresses
    {
        public FormattingRoutinesKeysForPrintingAddresses()
        {
            Countries = new HashSet<Countries>();
        }

        public int FormattingRoutineKeyForPrintingAddressesId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
    }
}