using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Categories
    {
        public Categories()
        {
            Persons = new HashSet<Persons>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Persons> Persons { get; set; }
    }
}