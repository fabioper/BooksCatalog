using BooksCatalog.Core.Books;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra
{
    public class BooksCatalogContext : DbContext
    {
        public BooksCatalogContext(DbContextOptions<BooksCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}