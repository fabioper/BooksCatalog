using BooksCatalog.Core.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksCatalog.Infra.Data.Configurations
{
    public class PublishersConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("Publishers")
                .HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Id);

            builder.HasMany(p => p.Books)
                .WithMany(p => p.Publishers);
        }
    }
}