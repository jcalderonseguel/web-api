using System;

namespace Domain.Entities
{
    public partial class Roles
    {
        public Guid Person { get; set; }
        public int RoleType { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual Persons PersonNavigation { get; set; }
        public virtual RolesTypes RoleTypeNavigation { get; set; }
    }
}