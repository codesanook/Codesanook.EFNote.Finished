using Codesanook.EFNote.Console.EntityConfigurations;
using Codesanook.EFNote.Console.Models;
using System.Data.Entity;

namespace Codesanook.EFNote.Console
{
    public class NoteDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public NoteDbContext() : base("NoteConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NoteDbContext>());
            //Set false to disable lazy loading
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteConfiguration());
            modelBuilder.Configurations.Add(new NotebookConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
        }
    }
}
