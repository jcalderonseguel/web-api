using System;

namespace Domain.Entities
{
    public partial class Attachments
    {
        public Guid Person { get; set; }
        public int AttachmentType { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string OwnerKey { get; set; }
        public string EncodedKey { get; set; }
        public decimal FileSize { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual AttachmentsTypes AttachmentTypeNavigation { get; set; }
        public virtual Persons PersonNavigation { get; set; }
    }
}