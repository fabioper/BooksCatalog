using BooksCatalog.Core.Authors;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Core.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
    }
}