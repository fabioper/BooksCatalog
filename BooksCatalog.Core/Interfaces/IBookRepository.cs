using BooksCatalog.Core.Books;
using BooksCatalog.Shared;

namespace BooksCatalog.Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}