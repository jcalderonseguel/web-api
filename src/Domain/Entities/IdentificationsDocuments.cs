using System;

namespace Domain.Entities
{
    public partial class IdentificationsDocuments
    {
        public Guid Person { get; set; }
        public int IdentificationDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? IssuingDate { get; set; }
        public string IssuingAuthority { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual DocumentsTypes IdentificationDocumentTypeNavigation { get; set; }
        public virtual Persons PersonNavigation { get; set; }
    }
}