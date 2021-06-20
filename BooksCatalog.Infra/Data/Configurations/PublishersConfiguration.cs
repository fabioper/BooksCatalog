using BooksCatalog.Domain.Publishers;
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

            builder.HasIndex(g => g.Id);
            builder.HasIndex(g => g.Name);

            builder.Property(g => g.Id);
            builder.Property(g => g.Name);

            builder.HasMany(p => p.Books)
                .WithMany(p => p.Publishers);
        }
    }
}