using Codesanook.EFNote.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codesanook.EFNote.MvcCoreWeb.ViewModels
{
    public class NoteIndexViewModel
    {
        public IReadOnlyCollection<(Notebook Value, bool IsSelected)> AllNotebooks { get; set; }
        public IReadOnlyCollection<(Note Value, bool IsSelected)> AllNotesInSelectedNotebook { get; set; }
    }
}
