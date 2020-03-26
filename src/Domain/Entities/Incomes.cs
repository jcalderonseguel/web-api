using System;

namespace Domain.Entities
{
    public partial class Incomes
    {
        public Guid Person { get; set; }
        public string Company { get; set; }
        public string Currency { get; set; }
        public decimal Value { get; set; }
        public int? Periodicity { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual Currencies CurrencyNavigation { get; set; }
        public virtual Periodicity PeriodicityNavigation { get; set; }
        public virtual Persons PersonNavigation { get; set; }
    }
}