using System.Collections.Generic;

namespace Codesanook.EFNote.Console.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
