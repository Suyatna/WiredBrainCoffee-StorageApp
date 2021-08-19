using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee_StorageApp.Entities;

namespace WiredBrainCoffee_StorageApp.Repositories
{
    public delegate void ItemAdded<in T>(T item);

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {        
        private readonly DbContext dbContext;
        private readonly ItemAdded<T>? itemAddedCallback;
        private readonly DbSet<T> dbSet;        

        public SqlRepository(DbContext dbContext, ItemAdded<T>? itemAddedCallback = null)
        {
            this.dbContext = dbContext;
            this.itemAddedCallback = itemAddedCallback;
            dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.OrderBy(item => item.Id).ToList();
        }

        public T GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        public void Add(T item)
        {
            dbSet.Add(item);
            itemAddedCallback?.Invoke(item);
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
