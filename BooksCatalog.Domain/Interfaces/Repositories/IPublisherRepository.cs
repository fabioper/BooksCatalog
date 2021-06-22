using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Domain.Publishers;
using BooksCatalog.Shared.Repositories;

namespace BooksCatalog.Domain.Interfaces.Repositories
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        IEnumerable<Publisher> GetByName(string name);
    }
}