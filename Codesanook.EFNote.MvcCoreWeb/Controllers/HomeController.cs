using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Codesanook.EFNote.MvcCoreWeb.Models;
using Codesanook.EFNote.Core;

namespace Codesanook.EFNote.MvcCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoteDbContext dbContext;

        public HomeController(NoteDbContext dbContext) => this.dbContext = dbContext;

        public IActionResult Index()
        {
            const int noteId = 1;
            var note = dbContext.Notes.Find(noteId);
            return View(note);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
