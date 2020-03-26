using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class DocumentsTypes
    {
        public DocumentsTypes()
        {
            IdentificationsDocuments = new HashSet<IdentificationsDocuments>();
        }

        public int DocumentTypeId { get; set; }
        public string Description { get; set; }

        public string Typecode { get; set; }

        public virtual ICollection<IdentificationsDocuments> IdentificationsDocuments { get; set; }
    }
}