using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Repositories;
using BooksCatalog.Shared.Specifications;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entitySet;

        protected BaseRepository(BooksCatalogContext context)
        {
            _context = context;
            _entitySet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _entitySet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entitySet.AsNoTracking().ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _entitySet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<T>> GetBy(Specification<T> spec)
        {
            return _entitySet.AsNoTracking()
                .Where(spec.ToExpression())
                .ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _entitySet.Update(entity));
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() => _entitySet.Remove(entity));
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}