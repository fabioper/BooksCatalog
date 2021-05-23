using BooksCatalog.Core.Books;
using BooksCatalog.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data
{
    public sealed class BooksCatalogContext : DbContext
    {
        public BooksCatalogContext(DbContextOptions<BooksCatalogContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BooksConfiguration());
        }
    }
}