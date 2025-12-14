using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketInventory.API.Repository
{
    public interface IRepository<T>
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> Get();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Save();
        Task<bool> Exist(string name);
        Task<bool> CategoryExist(int id);
    }
}