using BooksCatalog.Core.Genres;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Core.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
    }
}