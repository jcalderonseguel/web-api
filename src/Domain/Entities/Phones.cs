using System;

namespace Domain.Entities
{
    public partial class Phones
    {
        public Guid Person { get; set; }
        public int PhoneType { get; set; }
        public string CountryIsoCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual Countries CountryIsoCodeNavigation { get; set; }
        public virtual Persons PersonNavigation { get; set; }
        public virtual PhonesTypes PhoneTypeNavigation { get; set; }
    }
}