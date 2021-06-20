using BooksCatalog.Domain;
using BooksCatalog.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksCatalog.Infra.Data.Configurations
{
    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books")
                .HasKey(b => b.Id);

            builder.HasIndex(b => b.Id);
            
            builder.Property(b => b.Description);
            builder.Property(b => b.Title);
            builder.Property(b => b.ReleaseDate);
            builder.Property(b => b.CoverUri);

            builder.HasMany(b => b.Authors)
                .WithMany(a => a.Books);

            builder.HasMany(b => b.Genres)
                .WithMany(g => g.Books);

            builder.HasMany(b => b.Publishers)
                .WithMany(p => p.Books);
        }
    }
}