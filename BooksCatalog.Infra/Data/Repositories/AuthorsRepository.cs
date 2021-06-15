using BooksCatalog.Domain;
using BooksCatalog.Domain.Author;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Domain.Interfaces.Repositories;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorsRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}