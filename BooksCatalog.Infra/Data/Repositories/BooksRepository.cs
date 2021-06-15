using BooksCatalog.Domain;
using BooksCatalog.Domain.Books;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Domain.Interfaces.Repositories;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBookRepository
    {
        public BooksRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}