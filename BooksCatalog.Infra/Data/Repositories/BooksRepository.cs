using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Domain;
using BooksCatalog.Domain.Books;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBookRepository
    {
        public BooksRepository(BooksCatalogContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await EntitySet.AsNoTracking()
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Include(b => b.Publishers)
                .ToListAsync();
        }
    }
}