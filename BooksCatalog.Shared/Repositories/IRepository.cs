using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Shared.Specifications;

namespace BooksCatalog.Shared.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(int id);
        Task<List<T>> GetBySpec(Specification<T> spec);
        Task UpdateAsync(T entity);
        Task RemoveAsync(int id);
        Task CommitChangesAsync();
    }
}