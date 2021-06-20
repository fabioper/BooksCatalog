using BooksCatalog.Domain.Authors;
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
            builder.HasIndex(a => a.Name);

            builder.Property(a => a.Id);
            builder.Property(a => a.Name);
            builder.Property(a => a.ImageUri);
            builder.Property(a => a.BirthDate);
            builder.Property(a => a.Biography);

            builder.HasMany(a => a.Books)
                .WithMany(a => a.Authors);
        }
    }
}