using Codesanook.EFNote.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Codesanook.EFNote.Infrastructure.EntityConfigurations
{
    public class NoteConfiguration : EntityTypeConfiguration<Note>
    {
        public NoteConfiguration()
        {
            this.ToTable($"{nameof(Note)}s");
            this.HasKey<int>(x => x.Id);
            this.Property(x => x.Title);
            this.Property(x => x.Content);
            this.HasRequired(x => x.Notebook).WithMany(x=>x.Notes);
            this.HasMany(x => x.Tags).WithMany(x=>x.Notes);
        }
    }
}