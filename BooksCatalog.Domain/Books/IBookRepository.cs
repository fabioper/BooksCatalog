using BooksCatalog.Domain.Interfaces;

namespace BooksCatalog.Domain.Books
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}