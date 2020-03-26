using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class RolesTypes
    {
        public RolesTypes()
        {
            Roles = new HashSet<Roles>();
        }

        public int RoleTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Roles> Roles { get; set; }
    }
}