using Newtonsoft.Json;
using System;
using System.Linq;

namespace Codesanook.EFNote.ConsoleApp
{
    public class Program
    {
        static void CreateNote()
        {
            //Insert a new record with ORM (Entity Framework)
            using (var dbContext = new NoteDbContext())
            {
                // Create notebook
                var notebook = new Notebook()
                {
                    Name = "Programming Tips"
                };
                dbContext.Notebooks.Add(notebook);

                // Create tag
                var tag = new Tag
                {
                    Name = "ef"
                };
                dbContext.Tags.Add(tag);

                // Crate note
                var note = new Note()
                {
                    Title = "EF Tips",
                    ContentBody = "How to create entity classes from an existing database...",
                    CreatedUtc = DateTime.UtcNow,
                    Notebook = notebook
                };
                note.Tags.Add(tag);

                dbContext.Notes.Add(note);

                dbContext.SaveChanges();
                Console.WriteLine($"New notebook inserted with Id {notebook.Id}");
                Console.WriteLine($"New tag inserted with Id {tag.Id}");
                Console.WriteLine($"New note inserted with Id {note.Id}");
            }
        }

        static void GetNote()
        {
            using (var dbContext = new NoteDbContext())
            {
                var note = dbContext.Notes.Find(2);
                Console.WriteLine(note);
            }
        }

        static void UpdateNote()
        {
            Console.WriteLine("Before updating");
            GetNote();

            using (var dbContext = new NoteDbContext())
            {
                var note = dbContext.Notes.Find(2);
                note.Title = "EF configuration Tips";
                note.UpdatedUtc = DateTime.UtcNow;
                dbContext.SaveChanges();
            }

            Console.WriteLine("After updating");
            GetNote();
        }

        static void DeleteNote()
        {
            using (var dbContext = new NoteDbContext())
            {
                var note = dbContext.Notes.Find(2);
                dbContext.Notes.Remove(note);
                dbContext.SaveChanges();
            }
        }

        static void QueryNote()
        {
            using (var dbContext = new NoteDbContext())
            {
                var notebooks = dbContext.Notebooks.Where(b => b.Name.StartsWith("programming"));
                var notebook = notebooks.FirstOrDefault();
                foreach(var note in notebook.Notes)
                {
                    Console.WriteLine(note);
                }

                var tag = dbContext.Tags.Single(b => b.Name == "ef");
                foreach(var note in tag.Notes)
                {
                    Console.WriteLine(note);
                }

                var utcNow = DateTime.UtcNow;
                var createFromThisMonth = new DateTime(utcNow.Year, utcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);
                var notes = dbContext.Notes
                    .Where(n => n.CreatedUtc >= createFromThisMonth)
                    .OrderByDescending(n=>n.UpdatedUtc);

                foreach(var note in notes)
                {
                    Console.WriteLine(note);
                }
            }
        }

        static void QueryNoteWithJoin()
        {
            using (var dbContext = new NoteDbContext())
            {
                var notes = from b in dbContext.Notebooks
                           join n in dbContext.Notes
                           on b.Id equals n.NotebookId
                           select new { NoteBookName = b.Name, NoteTitle = n.Title };

                foreach(var note in notes)
                {
                    Console.WriteLine($"NoteBookName = {note.NoteBookName}, NoteTitle = {note.NoteTitle}");
                }
            }
        }

        public static void Main(string[] args)
        {
            QueryNoteWithJoin();
        }
    }
}
