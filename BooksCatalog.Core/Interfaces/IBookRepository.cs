using BooksCatalog.Core.Books;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}