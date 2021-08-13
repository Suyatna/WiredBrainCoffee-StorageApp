using System.Collections.Generic;
using WiredBrainCoffee_StorageApp.Entities;

namespace WiredBrainCoffee_StorageApp.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}