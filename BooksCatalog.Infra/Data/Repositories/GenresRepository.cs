using BooksCatalog.Core.Genres;
using BooksCatalog.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class GenresRepository : BaseRepository<Genre>, IGenreRepository
    {
        protected GenresRepository(DbContext context) : base(context)
        {
        }
    }
}