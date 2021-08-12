using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee_StorageApp.Entities;

namespace WiredBrainCoffee_StorageApp.Repositories
{
    public class GenericRepository<T> where T : IEntity
    {
        private readonly List<T> _items = new();

        public T GetById(int Id)
        {
            return _items.Single(item => item.Id == Id);
        }

        public void Add(T item)
        {
            item.Id = _items.Any() ? _items.Max(item => item.Id) + 1 : 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
