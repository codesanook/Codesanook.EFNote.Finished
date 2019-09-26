using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codesanook.EFNote.Core.DomainModels
{
    public class Tag:EntityBase
    {
        public Tag()
        {
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Name { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
