using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Currencies
    {
        public Currencies()
        {
            Countries = new HashSet<Countries>();
            Incomes = new HashSet<Incomes>();
        }

        public string IsoCode { get; set; }
        public int IsoNumber { get; set; }
        public int IsoDecimal { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
        public virtual ICollection<Incomes> Incomes { get; set; }
    }
}