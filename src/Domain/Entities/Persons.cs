using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Persons
    {
        public Persons()
        {
            Address = new HashSet<Address>();
            Attachments = new HashSet<Attachments>();
            Emails = new HashSet<Emails>();
            IdentificationsDocuments = new HashSet<IdentificationsDocuments>();
            Incomes = new HashSet<Incomes>();
            Phones = new HashSet<Phones>();
            Roles = new HashSet<Roles>();
        }

        public Guid PersonId { get; set; }
        public long TransactionId { get; set; }
        public long PersonNumber { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }

        public virtual Categories CategoryNavigation { get; set; }
        public virtual ClientsStatus StatusNavigation { get; set; }
        public virtual NaturalPersons NaturalPersons { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Attachments> Attachments { get; set; }
        public virtual ICollection<Emails> Emails { get; set; }
        public virtual ICollection<IdentificationsDocuments> IdentificationsDocuments { get; set; }
        public virtual ICollection<Incomes> Incomes { get; set; }
        public virtual ICollection<Phones> Phones { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
    }
}