using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ClientsStatus
    {
        public ClientsStatus()
        {
            Persons = new HashSet<Persons>();
        }

        public int ClientStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Persons> Persons { get; set; }
    }
}