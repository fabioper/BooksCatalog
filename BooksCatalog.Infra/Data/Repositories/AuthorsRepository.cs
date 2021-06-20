using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.Domain.Authors;
using BooksCatalog.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorsRepository(BooksCatalogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetByName(string name)
        {
            return await EntitySet.AsNoTracking()
                .Where(x => x.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync();
        }
    }
}