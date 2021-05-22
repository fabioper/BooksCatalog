using BooksCatalog.Core.Authors;
using BooksCatalog.Core.Interfaces;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorsRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}