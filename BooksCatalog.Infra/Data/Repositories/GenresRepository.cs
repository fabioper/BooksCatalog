using BooksCatalog.Core;
using BooksCatalog.Core.Genre;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Interfaces.Repositories;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class GenresRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenresRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}