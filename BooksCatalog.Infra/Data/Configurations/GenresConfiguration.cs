using BooksCatalog.Domain;
using BooksCatalog.Domain.Genre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksCatalog.Infra.Data.Configurations
{
    public class GenresConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres")
                .HasKey(g => g.Id);

            builder.HasIndex(g => g.Id);
            builder.HasIndex(g => g.Name);

            builder.Property(g => g.Id);
            builder.Property(g => g.Name);
            
            builder.HasMany(g => g.Books)
                .WithMany(g => g.Genres);
        }
    }
}