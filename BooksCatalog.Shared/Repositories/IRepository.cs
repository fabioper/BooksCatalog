using System.Collections.Generic;
using BooksCatalog.Shared.Specifications;

namespace BooksCatalog.Shared.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void AddAsync(T entity);
        IEnumerable<T> GetAllAsync();
        T FindByIdAsync(int id);
        List<T> GetBy(Specification<T> spec);
        void UpdateAsync(T entity);
        void RemoveAsync(T entity);
        void CommitChangesAsync();
    }
}