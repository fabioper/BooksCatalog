using System.Collections.Generic;

namespace BooksCatalog.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        IEnumerable<T> GetAll(T entity);
        T FindById(int id);
        void Update(T entity);
        void Remove(int id);
        void CommitChanges();
    }
}