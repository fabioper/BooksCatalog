using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Domain.Genres;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Domain.Interfaces.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetByName(string name);
    }
}