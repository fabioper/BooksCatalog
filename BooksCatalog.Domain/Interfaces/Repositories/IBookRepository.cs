using BooksCatalog.Domain.Books;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}