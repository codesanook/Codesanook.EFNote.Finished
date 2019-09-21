using Codesanook.EFNote.Core.Models;

namespace Codesanook.EFNote.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Insert a new record with ORM (Entity Framework)
            using (var dbContext = new NoteDbContext())
            {
                var notebook = new Notebook()
                {
                    Name = "Programming Tips"
                };

                dbContext.Notebooks.Add(notebook);
                dbContext.SaveChanges();

                System.Console.WriteLine($"New notebook inserted with Id {notebook.Id}");
            }
        }
    }
}
