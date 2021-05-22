using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BooksCatalog.Shared
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

    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}