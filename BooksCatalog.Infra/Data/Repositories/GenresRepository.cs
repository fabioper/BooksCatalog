using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.Domain.Genres;
using BooksCatalog.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class GenresRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenresRepository(BooksCatalogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Genre>> GetByName(string name)
        {
            return await EntitySet.AsNoTracking()
                .Where(x => x.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync();
        }
    }
}