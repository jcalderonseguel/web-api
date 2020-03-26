using System;

namespace Domain.Entities
{
    public partial class Emails
    {
        public Guid Person { get; set; }
        public string EmailAddress { get; set; }
        public bool? Validated { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual Persons PersonNavigation { get; set; }
    }
}