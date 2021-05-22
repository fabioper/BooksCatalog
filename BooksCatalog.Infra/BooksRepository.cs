using BooksCatalog.Core.Books;
using BooksCatalog.Core.Interfaces;
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