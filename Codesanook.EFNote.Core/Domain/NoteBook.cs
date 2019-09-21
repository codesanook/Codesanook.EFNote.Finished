using System.Collections.Generic;

namespace Codesanook.EFNote.Core.Models
{
    public class Notebook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
