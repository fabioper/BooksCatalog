using BooksCatalog.Domain;
using BooksCatalog.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra
{
    public class BooksRepository : BaseRepository<Book>, IBookRepository
    {
        public BooksRepository(DbContext context) : base(context)
        {
        }
    }
}