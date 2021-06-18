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
        protected readonly DbSet<T> EntitySet;

        protected BaseRepository(BooksCatalogContext context)
        {
            _context = context;
            EntitySet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await EntitySet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await EntitySet.AsNoTracking().ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<T>> GetBy(Specification<T> spec)
        {
            return EntitySet.AsNoTracking()
                .Where(spec.ToExpression())
                .ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            EntitySet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() => EntitySet.Remove(entity));
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}