using System.Collections.Generic;
using WiredBrainCoffee_StorageApp.Entities;

namespace WiredBrainCoffee_StorageApp.Repositories
{
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
    }

    public interface IRepository<T> : IReadRepository<T> where T : IEntity
    {        
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}