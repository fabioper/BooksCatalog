using BooksCatalog.Core.Genres;
using BooksCatalog.Core.Interfaces;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class GenresRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenresRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}