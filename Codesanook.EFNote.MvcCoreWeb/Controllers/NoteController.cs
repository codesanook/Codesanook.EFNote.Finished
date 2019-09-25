using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Codesanook.EFNote.MvcCoreWeb.Models;
using Codesanook.EFNote.Core;
using Codesanook.EFNote.MvcCoreWeb.ViewModels;
using System.Linq;
using Codesanook.EFNote.Core.DomainModels;
using System.Data.Entity;

namespace Codesanook.EFNote.MvcCoreWeb.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteDbContext dbContext;

        public NoteController(NoteDbContext dbContext) => this.dbContext = dbContext;
        public const string ErrorMessageKey = "errorMessage";

        public IActionResult Index(int? selectedNotebookId, int? selectedNoteId)
        {
            var allNotebooks = dbContext.Notebooks.ToList();
            var selectedNotebook = allNotebooks.SingleOrDefault(b => b.Id == selectedNotebookId);

            var allNotesForSelectedNotebook = dbContext.Notes
                .Where(n => n.Notebook.Id == selectedNotebookId)
                .Include(n => n.Tags)
                .AsEnumerable()
                .Select(n => new NoteViewModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    NotebookId = n.NotebookId,
                    Tags = string.Join(", ", n.Tags.Select(t => t.Name)),
                })
                .ToList();

            var selectedNote = allNotesForSelectedNotebook.SingleOrDefault(n => n.Id == selectedNoteId);
            var model = new NoteIndexViewModel()
            {
                AllNotebooks = allNotebooks,
                SelectedNotebook = selectedNotebook,
                AllNotesForSelectedNotebook = allNotesForSelectedNotebook,
                SelectedNote = selectedNote
            };
            return View(model);
        }

        public IActionResult Create(int? selectedNotebookId)
        {
            if(selectedNotebookId == null)
            {
                TempData[nameof(ErrorMessageKey)] = "Notebook not selected. If not exist, please create new and select";
                return RedirectToAction(nameof(Index));
            }

            var allNotebooks = dbContext.Notebooks.ToList();
            var selectedNotebook = allNotebooks.SingleOrDefault(b => b.Id == selectedNotebookId);

            var allNotesForSelectedNotebook = dbContext.Notes
                .Where(n => n.Notebook.Id == selectedNotebookId)
                .Include(n => n.Tags)
                .AsEnumerable()
                .Select(n => new NoteViewModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    NotebookId = n.NotebookId,
                    Tags = string.Join(", ", n.Tags.Select(t => t.Name)),
                })
                .ToList();

            var model = new NoteIndexViewModel()
            {
                AllNotebooks = allNotebooks,
                SelectedNotebook = selectedNotebook,
                AllNotesForSelectedNotebook = allNotesForSelectedNotebook,
            };
            return View(nameof(Index), model);
        }

        [HttpPost]
        public IActionResult Create([Bind(Prefix = "SelectedNote")] NoteViewModel viewModel)
        {
            var note = new Note()
            {
                Title = viewModel.Title,
                Content = viewModel.Content,
                NotebookId = viewModel.NotebookId
            };

            //var tags = viewModel.Tags.Select(t => new Tag { Id = t.Id });
            //foreach (var tag in tags)
            //{
            //    dbContext.Entry(tag).State = EntityState.Unchanged;
            //    note.Tags.Add(tag);
            //}

            dbContext.Notes.Add(note);
            dbContext.SaveChanges();
            return RedirectToIndex(note);
        }

        public IActionResult Edit(int id, [Bind(Prefix = "SelectedNote")] Note note)
        {
            var existingNote = dbContext.Notes.SingleOrDefault(n => n.Id == id);
            existingNote.Title = note.Title;
            existingNote.Content = note.Content;
            existingNote.NotebookId = note.NotebookId;//update notebook
            dbContext.SaveChanges();
            return RedirectToIndex(existingNote);
        }

        private IActionResult RedirectToIndex(Note note)
        {
            return RedirectToAction(
                nameof(Index),
                new
                {
                    selectedNotebookId = note.NotebookId,
                    selectedNoteId = note.Id
                });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
