using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Periodicity
    {
        public Periodicity()
        {
            Incomes = new HashSet<Incomes>();
        }

        public int PeriodicityId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Incomes> Incomes { get; set; }
    }
}