using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketInventory.API.Models;

namespace SupermarketInventory.API.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        public Task Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}