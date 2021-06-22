using System.Collections.Generic;
using BooksCatalog.Domain.Authors;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetByName(string name);
    }
}