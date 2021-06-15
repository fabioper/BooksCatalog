using BooksCatalog.Core.Books;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Core.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}