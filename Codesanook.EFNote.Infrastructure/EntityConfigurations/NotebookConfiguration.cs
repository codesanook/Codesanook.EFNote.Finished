using Codesanook.EFNote.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Codesanook.EFNote.Infrastructure.EntityConfigurations
{
    public class NotebookConfiguration : EntityTypeConfiguration<Notebook>
    {
        public NotebookConfiguration()
        {
            //TODO check auto plural in EF
            this.ToTable($"{nameof(Notebook)}s");

            this.HasKey<int>(x => x.Id);
            this.Property(x => x.Name);
            this.HasMany(x => x.Notes).WithRequired(x=>x.Notebook);
        }
    }
}