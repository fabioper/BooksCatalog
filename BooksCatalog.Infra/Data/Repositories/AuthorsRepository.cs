using BooksCatalog.Core;
using BooksCatalog.Core.Author;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Interfaces.Repositories;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorsRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}