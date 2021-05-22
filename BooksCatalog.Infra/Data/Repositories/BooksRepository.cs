using BooksCatalog.Core.Books;
using BooksCatalog.Core.Interfaces;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBookRepository
    {
        public BooksRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}