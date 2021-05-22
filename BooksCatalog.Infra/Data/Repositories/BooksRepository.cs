using BooksCatalog.Core.Books;
using BooksCatalog.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBookRepository
    {
        public BooksRepository(DbContext context) : base(context)
        {
        }
    }
}