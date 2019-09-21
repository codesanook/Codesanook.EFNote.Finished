namespace Codesanook.EFNote.ConsoleApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NoteDbContext : DbContext
    {
        public NoteDbContext()
            : base("name=NoteDbContext")
        {
        }

        public virtual DbSet<Notebook> Notebooks { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Notes)
                .Map(m => m.ToTable("NoteTags").MapLeftKey("NoteId").MapRightKey("TagId"));
        }
    }
}
