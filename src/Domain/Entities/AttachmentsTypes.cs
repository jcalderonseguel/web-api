using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class AttachmentsTypes
    {
        public AttachmentsTypes()
        {
            Attachments = new HashSet<Attachments>();
        }

        public int AttachmentTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Attachments> Attachments { get; set; }
    }
}