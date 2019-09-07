using System;
using System.Collections.Generic;

namespace Codesanook.EFNote.Console.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public int SharedViewCount { get; set; }

        public virtual Notebook Notebook { get; set; }

        //TODO why ICollection not IList
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
