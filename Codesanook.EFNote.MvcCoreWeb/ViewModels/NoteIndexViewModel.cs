using Codesanook.EFNote.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codesanook.EFNote.MvcCoreWeb.ViewModels
{
    public class NoteIndexViewModel
    {
        public IReadOnlyCollection<Notebook> AllNotebooks { get; set; }
        public Notebook SelectedNotebook { get; set; }
        public IReadOnlyCollection<NoteViewModel> AllNotesForSelectedNotebook { get; set; }
        public NoteViewModel SelectedNote { get; set; }
    }
}
