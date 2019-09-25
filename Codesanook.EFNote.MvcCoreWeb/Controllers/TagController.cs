using Codesanook.EFNote.Core;
using Codesanook.EFNote.Core.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codesanook.EFNote.MvcCoreWeb.Controllers
{
    public class TagController : Controller
    {
        private readonly NoteDbContext dbContext;

        public TagController(NoteDbContext dbContext) => this.dbContext = dbContext;

        public IActionResult Index()
        {
            var tags = dbContext.Tags.ToList();
            return View(tags);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Tag model)
        {
            model.Name = FormatTagName(model.Name);
            dbContext.Tags.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var tags = dbContext.Tags.Find(id);
            return View(tags);
        }

        [HttpPost]
        public IActionResult Edit(int id, Tag model)
        {
            var existingNotebook = dbContext.Tags.Find(id);
            existingNotebook.Name = FormatTagName(model.Name);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var tag = dbContext.Tags.Find(id);
            return View(tag);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection formCollection)
        {
            var tag = dbContext.Tags.Find(id);
            foreach (var note in tag.Notes)
            {
                tag.Notes.Remove(note);//remove relationship but note remove actual note from a database
            }
            dbContext.Tags.Remove(tag);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private static string FormatTagName(string tagName) => 
            Regex.Replace(tagName.Trim(), @"\s+", "-").ToLower();
        

    }
}
