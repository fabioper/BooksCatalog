using System.Collections.Generic;
using System.Linq;
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

        protected BaseRepository(DbContext context)
        {
            _context = context;
            EntitySet = _context.Set<T>();
        }

        public void AddAsync(T entity)
        {
            EntitySet.Add(entity);
        }

        public IEnumerable<T> GetAllAsync()
        {
            return EntitySet.AsNoTracking().ToList();
        }

        public T FindByIdAsync(int id)
        {
            return EntitySet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetBy(Specification<T> spec)
        {
            return EntitySet.AsNoTracking()
                .Where(spec.ToExpression())
                .ToList();
        }

        public void UpdateAsync(T entity)
        {
            EntitySet.Update(entity);
        }

        public void RemoveAsync(T entity)
        {
            EntitySet.Remove(entity);
        }

        public void CommitChangesAsync()
        {
            _context.SaveChanges();
        }
    }
}