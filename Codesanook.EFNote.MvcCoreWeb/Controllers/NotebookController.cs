using Codesanook.EFNote.Core;
using Codesanook.EFNote.Core.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Codesanook.EFNote.MvcCoreWeb.Controllers
{
    public class NotebookController : Controller
    {
        private readonly NoteDbContext dbContext;

        public NotebookController(NoteDbContext dbContext) => this.dbContext = dbContext;

        public IActionResult Index()
        {
            var notebooks = dbContext.Notebooks.ToList();
            return View(notebooks);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Notebook model)
        {
            model.Name = model.Name.Trim();
            dbContext.Notebooks.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var notebook = dbContext.Notebooks.Find(id);
            return View(notebook);
        }

        [HttpPost]
        public IActionResult Edit(int id, Notebook model)
        {
            model.Name = model.Name.Trim();
            var existingNotebook = dbContext.Notebooks.Find(id);
            existingNotebook.Name = model.Name;
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var notebook = dbContext.Notebooks.Find(id);
            return View(notebook);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection _)
        {
            var notebook = dbContext.Notebooks.Find(id);
            var notes = notebook.Notes;

            var noteTags = from note in notes
                           from tag in note.Tags
                           select (note, tag);

            foreach (var (note, tag) in noteTags)
            {
                note.Tags.Remove(tag);
            }

            dbContext.Notes.RemoveRange(notes);
            dbContext.Notebooks.Remove(notebook);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
