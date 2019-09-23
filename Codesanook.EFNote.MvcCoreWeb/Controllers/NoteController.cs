using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Codesanook.EFNote.MvcCoreWeb.Models;
using Codesanook.EFNote.Core;
using Codesanook.EFNote.MvcCoreWeb.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Codesanook.EFNote.Core.DomainModels;

namespace Codesanook.EFNote.MvcCoreWeb.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteDbContext dbContext;

        public NoteController(NoteDbContext dbContext) => this.dbContext = dbContext;

        public IActionResult Index(int? selectedNotebookId)
        {
            var model = new NoteIndexViewModel()
            {
                AllNotebooks = GetAllNotebook(selectedNotebookId),
            };
            return View(model);
        }

        private IReadOnlyCollection<(Notebook Value, bool IsSelected)> GetAllNotebook(int? selectedNotebookId)
        {
            return dbContext.Notebooks
                .ToList()
                .Select(
                    b => (
                        Value: b, 
                        IsSelected: b.Id == selectedNotebookId
                    )
                ).ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
