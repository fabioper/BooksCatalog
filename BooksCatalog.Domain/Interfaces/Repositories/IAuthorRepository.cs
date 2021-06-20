using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Domain.Authors;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetByName(string name);
    }
}