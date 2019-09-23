using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Codesanook.EFNote.Core.DomainModels
{
    public class Tag
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
