using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Countries
    {
        public Countries()
        {
            NaturalPersons = new HashSet<NaturalPersons>();
            Phones = new HashSet<Phones>();
            Regions = new HashSet<Regions>();
        }

        public string CountryIsoCode { get; set; }
        public string Description { get; set; }
        public int CountryIsoNumb { get; set; }
        public string PrincipalCurrency { get; set; }
        public int? PostalCodeLength { get; set; }
        public int? RuleForPostalCode { get; set; }
        public int? FormattingRoutineKeyForPrintingAddresses { get; set; }
        public int? LanguageKey { get; set; }
        public string Nationality { get; set; }
        public string IsoCountryName { get; set; }
        public string OfficialStateName { get; set; }

        public virtual FormattingRoutinesKeysForPrintingAddresses FormattingRoutineKeyForPrintingAddressesNavigation { get; set; }
        public virtual LanguagesKeys LanguageKeyNavigation { get; set; }
        public virtual Currencies PrincipalCurrencyNavigation { get; set; }
        public virtual RuleForPostalsCodes RuleForPostalCodeNavigation { get; set; }
        public virtual ICollection<NaturalPersons> NaturalPersons { get; set; }
        public virtual ICollection<Phones> Phones { get; set; }
        public virtual ICollection<Regions> Regions { get; set; }
    }
}