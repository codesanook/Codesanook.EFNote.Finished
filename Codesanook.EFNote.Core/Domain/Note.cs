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
        public int ViewCount { get; set; }
        public virtual Notebook Notebook { get; set; }

        //TODO why ICollection not IList
        public virtual ICollection<Tag> Tags { get; set; }
        //https://stackoverflow.com/questions/1162816/naming-conventions-state-versus-status
        public string Status { get; set; } //Active, Archived, Deleted convert to adjust
    }
}
