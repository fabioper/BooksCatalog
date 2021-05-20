using System.Collections.Generic;
using System.Threading.Tasks;
using BooksCatalog.Core.Common;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        protected readonly DbSet<T> EntitySet;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            EntitySet = _context.Set<T>();
        }

        public async Task AddAsync(T entity) =>
            await EntitySet.AddAsync(entity);

        public async Task<IEnumerable<T>> GetAllAsync(T entity) =>
            await EntitySet.AsNoTracking().ToListAsync();

        public async Task<T> FindByIdAsync(int id) =>
            await EntitySet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task CommitChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}