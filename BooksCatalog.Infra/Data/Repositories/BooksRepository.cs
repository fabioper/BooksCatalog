using System.Collections.Generic;
using System.Linq;
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

        public new IEnumerable<Book> GetAllAsync()
        {
            return EntitySet.AsNoTracking()
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Include(b => b.Publishers)
                .OrderByDescending(x => x.CreationDate)
                .ToList();
        }

        public new Book FindByIdAsync(int id)
        {
            return EntitySet.AsNoTracking()
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Include(b => b.Publishers)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}