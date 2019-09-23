using Codesanook.EFNote.Core.DomainModels;
using System.Data.Entity;

namespace Codesanook.EFNote.Core
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<Notebook> Notebooks { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notebook>()
                .HasMany(e => e.Notes)
                .WithRequired(e => e.Notebook)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Note>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Notes)
                .Map(m => m.ToTable("NoteTags").MapLeftKey("NoteId").MapRightKey("TagId"));
        }
    }
}
