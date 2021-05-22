using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Shared;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entitySet;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            _entitySet = _context.Set<T>();
        }

        public async Task AddAsync(T entity) =>
            await _entitySet.AddAsync(entity);

        public async Task<IEnumerable<T>> GetAllAsync(T entity) =>
            await _entitySet.AsNoTracking().ToListAsync();

        public async Task<T> FindByIdAsync(int id) =>
            await _entitySet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CommitChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}