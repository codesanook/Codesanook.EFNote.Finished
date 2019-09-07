using Codesanook.EFNote.Console.Models;
using System.Data.Entity.ModelConfiguration;

namespace Codesanook.EFNote.Console.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            this.ToTable($"{nameof(Tag)}s");
            this.HasKey<int>(x => x.Id);
            this.Property(x => x.Name);
            this.HasMany(x => x.Notes).WithMany(x => x.Tags);
        }
    }
}