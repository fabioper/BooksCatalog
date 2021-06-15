using BooksCatalog.Core;
using BooksCatalog.Core.Books;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Interfaces.Repositories;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBookRepository
    {
        public BooksRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}