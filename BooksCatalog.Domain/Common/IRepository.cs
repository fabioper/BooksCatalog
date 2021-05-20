using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksCatalog.Core.Common
{
    public interface IRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(T entity);
        Task<T> FindByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task RemoveAsync(int id);
        Task CommitChangesAsync();
    }
}