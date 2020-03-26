using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class LanguagesKeys
    {
        public LanguagesKeys()
        {
            Countries = new HashSet<Countries>();
        }

        public int LanguageKeyId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
    }
}