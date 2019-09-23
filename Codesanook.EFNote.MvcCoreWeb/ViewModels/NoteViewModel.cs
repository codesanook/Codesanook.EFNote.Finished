using Codesanook.EFNote.Core.DomainModels;
using System.Collections.Generic;

namespace Codesanook.EFNote.MvcCoreWeb.ViewModels
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int NotebookId { get; set; }
        public string Tags { get; set; }
    }
}
