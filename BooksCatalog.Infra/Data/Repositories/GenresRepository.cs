using BooksCatalog.Domain;
using BooksCatalog.Domain.Genre;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Domain.Interfaces.Repositories;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class GenresRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenresRepository(BooksCatalogContext context) : base(context)
        {
        }
    }
}