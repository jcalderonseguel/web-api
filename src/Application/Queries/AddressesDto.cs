
namespace Application.Queries
{
    public class AddressesDto
    {
        public string AddressType { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string AddressLine { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? AddressCodeStatus { get; set; }
    }
}
