using System;

namespace Domain.Entities
{
    public partial class Address
    {
        public Guid Person { get; set; }
        public int AddressType { get; set; }
        public int? City { get; set; }
        public int? StatusCodeAddress { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string AddressLine { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string PostOfficeBoxCode { get; set; }
        public string PoboxPostalCode { get; set; }
        public string Coname { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string Neighborhood { get; set; }
        public virtual AddressesTypes AddressTypeNavigation { get; set; }
        public virtual Cities CityNavigation { get; set; }
        public virtual Persons PersonNavigation { get; set; }
        public virtual StatusCodesAddresses StatusCodeAddressNavigation { get; set; }
    }
}