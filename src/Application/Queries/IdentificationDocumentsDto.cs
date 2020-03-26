using System;

namespace Application.Queries
{
    public class IdentificationDocumentsDto
    {
        public IdentificationDocumentTypeDto IdentificationDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssueAuthority { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

    }
}
