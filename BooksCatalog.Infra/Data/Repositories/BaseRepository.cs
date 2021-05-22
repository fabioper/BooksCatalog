using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.Shared;
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

        public Task<List<T>> GetBySpec(Specification<T> spec)
        {
            return _entitySet.AsNoTracking()
                .Where(spec.ToExpression())
                .ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}