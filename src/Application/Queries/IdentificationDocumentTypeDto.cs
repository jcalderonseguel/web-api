namespace Application.Queries
{
    public class IdentificationDocumentTypeDto
    {
        public int IdType { get; set; }
        public string Description { get; set; }
        public CountryDto Country { get; set; }
        public bool CheckDigit { get; set; }
    }
}
