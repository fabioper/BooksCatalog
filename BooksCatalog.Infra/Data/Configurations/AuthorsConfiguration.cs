using BooksCatalog.Domain;
using BooksCatalog.Domain.Author;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksCatalog.Infra.Data.Configurations
{
    public class AuthorsConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors")
                .HasKey(a => a.Id);

            builder.HasIndex(a => a.Id);
            builder.HasIndex(a => a.FirstName);
            builder.HasIndex(a => a.LastName);

            builder.Property(a => a.Id);
            builder.Property(a => a.FirstName);
            builder.Property(a => a.LastName);
            builder.Property(a => a.ImageUri);
            builder.Property(a => a.BirthDate);
            builder.Property(a => a.Biography);

            builder.HasMany(a => a.Books)
                .WithMany(a => a.Authors);
        }
    }
}