using BooksCatalog.Core.Authors;
using BooksCatalog.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorRepository
    {
        protected AuthorsRepository(DbContext context) : base(context)
        {
        }
    }
}