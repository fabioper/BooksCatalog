using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.Domain.Interfaces.Repositories;
using BooksCatalog.Domain.Publishers;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class PublishersRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublishersRepository(BooksCatalogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Publisher>> GetByName(string name)
        {
            return await EntitySet.AsNoTracking()
                .Where(x => x.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync();
        }
    }
}